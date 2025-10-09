using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Windows.Forms;

using BSE.Platten.BO;
using System.Globalization;
using System.Collections.ObjectModel;
using BSE.Platten.FreeDb.Properties;

namespace BSE.Platten.FreeDb
{
	/// <summary>
    /// Zusammenfassung für FreeDb.
	/// </summary>
	public class FreeDb
	{
		#region FieldsPrivate
        private IWin32Window m_Owner;
        #endregion
		
		#region MethodsPublic

		public FreeDb()
		{
		}
        
        public FreeDb(IWin32Window owner)
            : this()
        {
            this.m_Owner = owner;
        }

		public BSE.Platten.BO.Album GetMediaDataForCD(string strDiskId)
		{
            Album album = null;
            try
			{
                Collection<string> freeDbResponse = GetBaseResponseFromFreeDb(strDiskId);
                if (freeDbResponse.Count > 0)
				{
                    MatchCode matchCode = GetMatchCode(freeDbResponse);
					switch (matchCode)
					{
						case MatchCode.NoMatch:
                            throw new BSE.Platten.FreeDb.FreeDBMatchNoneException(Resources.IDS_NoMatchException);		
						case MatchCode.ExactMatch:
                            string strResponse = freeDbResponse[0];
                            if (string.IsNullOrEmpty(strResponse) == false)
                            {
                                string[] aResponse = GetArrayFromResponse(strResponse);
                                if ((aResponse != null) && (aResponse.Length > 2))
                                {
                                    string strGenre = aResponse[1];
                                    string strMediaId = aResponse[2];
                                    if ((string.IsNullOrEmpty(strGenre) == false) &&
                                        (string.IsNullOrEmpty(strMediaId) == false))
                                    {
                                        album = GetAlbumFromFreeDb(strGenre, strMediaId);
                                    }
                                }
                            }
							break;
						case MatchCode.MultipleMatches:
                            album = GetSelectedAlbumFromFreeDb(freeDbResponse);
							break;
					}
				}
                return album;
			}
			catch (Exception)
			{
				throw;
			}
		}

		#endregion

		#region MethodsPrivate

        private Collection<string> GetBaseResponseFromFreeDb(string strDiskId)
        {
            string strQueryRequestURL = "cddb+query+" + strDiskId;
            return GetResponse(Constants.PreRequestURL + strQueryRequestURL + GetPostRequestURL());
        }

        private static Collection<string> GetResponse(string strRequestUrl)
        {
            Collection<string> freeDbResponse = null;
            using (WebClient webClient = new WebClient())
            {
                using (Stream stream = webClient.OpenRead(strRequestUrl))
                {
                    using (StreamReader streamReader = new StreamReader(stream))
                    {
                        while (streamReader.Peek() >= 0)
                        {
                            if (freeDbResponse == null)
                            {
                                freeDbResponse = new Collection<string>();
                            }
                            freeDbResponse.Add(streamReader.ReadLine());
                        }
                    }
                }
            }
            return freeDbResponse;
        }

		private static MatchCode GetMatchCode(Collection<string> freeDbResponse)
		{
			MatchCode matchCode = MatchCode.NoMatch;
            if ((freeDbResponse != null) && (freeDbResponse.Count > 0))
            {
                int iStatusCode = GetStatusCode(freeDbResponse);
                switch (iStatusCode)
                {
                    case 200:
                        //exact match, read details
                        matchCode = MatchCode.ExactMatch;
                        break;
                    case 202:
                        //couldn't find CD-ID from CDDB "cddb query" command
                        matchCode = MatchCode.NoMatch;
                        break;
                    case 210:
                    case 211:
                        matchCode = MatchCode.MultipleMatches;
                        break;
                }
            }
			return matchCode;
		}

        private static int GetStatusCode(Collection<string> freeDbResponse)
        {
            int iStatusCode = -1;
            if ((freeDbResponse != null) && (freeDbResponse.Count > 0))
            {
                string strResponse = freeDbResponse[0];
                string strStatusCode = strResponse.Substring(0, 3);
                int.TryParse(strStatusCode, out iStatusCode);
            }
            return iStatusCode;
        }

        private Album GetAlbumFromFreeDb(string strGenre, string strMediaId)
        {
            Album album = null;
            string strQueryRequestURL = "cddb+read+" + strGenre + "+" + strMediaId;
            Collection<string> freeDbResponse = GetResponse(Constants.PreRequestURL + strQueryRequestURL + GetPostRequestURL());
            if ((freeDbResponse != null) && (freeDbResponse.Count > 0))
            {
                album = ParseCDInformationFromFreeDb(freeDbResponse);
            }
            return album;
        }

        private static Album ParseCDInformationFromFreeDb(Collection<string> freeDbResponse)
		{
            Album album = null;
            if ((freeDbResponse != null) && (freeDbResponse.Count > 0))
            {
                int iStatusCode = GetStatusCode(freeDbResponse);
                //OK, CDDB database entry follows (until terminating marker)
                if (iStatusCode == 210)
                {
                    album = new Album();
                    System.Collections.Generic.List<CTrack> currentTracks = null;
                    for (int i = 0; i < freeDbResponse.Count; i++)
                    {
                        string strResponse = freeDbResponse[i];
                        if (strResponse == ".")
                        {
                            break;
                        }
                        //year info
                        if (strResponse.StartsWith(Constants.KeyYear, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            album.Year = GetIntValue(strResponse, Constants.KeyYear);
                        }

                        //genre info
                        if (strResponse.StartsWith(Constants.KeyGenre, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            album.Genre = GetStringValue(strResponse, Constants.KeyGenre);
                        }

                        //artist/album info
                        if (strResponse.StartsWith(Constants.KeyArtistInfo, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            string strArtistInfo = GetStringValue(strResponse, Constants.KeyArtistInfo);
                            if (string.IsNullOrEmpty(strArtistInfo) == false)
                            {
                                string[] aArtistInfos = strArtistInfo.Split(
                                    Constants.ArtistInfoDelimiter, StringSplitOptions.RemoveEmptyEntries);
                                if (aArtistInfos != null)
                                {
                                    string strInterpret = aArtistInfos[0];
                                    if (string.IsNullOrEmpty(strInterpret) == false)
                                    {
                                        album.Interpret = strInterpret.Trim();
                                    }
                                    if (aArtistInfos.Length == 2)
                                    {
                                        string strTitle = aArtistInfos[1];
                                        if (string.IsNullOrEmpty(strTitle) == false)
                                        {
                                            album.Title = strTitle.Trim();
                                        }
                                    }
                                }
                            }
                        }

                        //Track titles
                        if (strResponse.StartsWith(Constants.KeyTitles, StringComparison.OrdinalIgnoreCase) == true)
                        {
                            string strTrackNumber = GetTrackNumber(strResponse, Constants.KeyTitles);
                            if (string.IsNullOrEmpty(strTrackNumber) == false)
                            {
                                int iTrackIndex = -1;
                                if (int.TryParse(strTrackNumber, out iTrackIndex) == true)
                                {
                                    string strKey = Constants.KeyTitles + strTrackNumber + "=";
                                    CTrack track = new CTrack();
                                    track.TrackNumber = iTrackIndex + 1;
                                    string strTrack = GetStringValue(strResponse, strKey);
                                    if (string.IsNullOrEmpty(strTrack) == false)
                                    {
                                        track.Title = strTrack.Trim();
                                    }
                                    if (currentTracks == null)
                                    {
                                        currentTracks = new System.Collections.Generic.List<CTrack>();
                                    }
                                    currentTracks.Add(track);
                                }
                            }
                        }
                    }
                    if (currentTracks != null)
                    {
                        album.Tracks = currentTracks.ToArray();
                    }
                }
            }
            return album;
		}

        private Album GetSelectedAlbumFromFreeDb(Collection<string> freeDbResponse)
		{
            Album album = null;
            try
            {
                using (SelectCDForm frmSelectCD = new SelectCDForm(freeDbResponse))
                {
                    //Form parentForm = frmSelectCD.FindForm();
                    Form parentForm = this.m_Owner as Form;
                    if (parentForm != null)
                    {
                        frmSelectCD.StartPosition = FormStartPosition.CenterParent;
                    }
                    if (frmSelectCD.ShowDialog() == DialogResult.OK)
                    {
                        string strSelectedCD = frmSelectCD.SelectedCD;
                        if (string.IsNullOrEmpty(strSelectedCD) == false)
                        {
                            string[] aResponse = GetArrayFromResponse(strSelectedCD);
                            if ((aResponse != null) && (aResponse.Length > 1))
                            {
                                string strGenre = aResponse[0];
                                string strMediaId = aResponse[1];
                                if ((string.IsNullOrEmpty(strGenre) == false) &&
                                    (string.IsNullOrEmpty(strMediaId) == false))
                                {
                                    album = GetAlbumFromFreeDb(strGenre, strMediaId);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return album;
		}

		private string GetPostRequestURL()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("&");
			stringBuilder.Append(Constants.Hello);
			stringBuilder.Append("+");
			stringBuilder.Append(GetAssemblyName());
			stringBuilder.Append("+1&");
			stringBuilder.Append(Constants.Protocol);
			return stringBuilder.ToString();
		}

		private string GetAssemblyName()
		{
            string strAssemblyName = string.Empty;
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
                if (assembly == null)
                {
                    assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    if (assembly == null)
                    {
                        assembly = System.Reflection.Assembly.GetAssembly(GetType());
                    }
                }
                strAssemblyName = assembly.GetName().Name;
            }
            catch
            {
                strAssemblyName = string.Format(CultureInfo.InvariantCulture,"Configuration");
            }
            return strAssemblyName;
		}

        private static int GetIntValue(string strValue, string strKey)
        {
            int iValue = 0;
            string strTrim = strValue.TrimStart(strKey.ToCharArray());
            if (int.TryParse(strTrim, out iValue) == true)
            {
                return iValue;
            }
            return iValue;
        }

        private static string GetStringValue(string strValue, string strKey)
        {
            return strValue.Substring(strKey.Length);
        }

        private static string GetTrackNumber(string strValue, string strKey)
        {
            string strTrackNumber = null;
            strValue = GetStringValue(strValue, strKey);
            if (string.IsNullOrEmpty(strValue) == false)
            {
                strTrackNumber = strValue.Substring(0, strValue.IndexOf('='));
            }
            return strTrackNumber;
        }

        private static string[] GetArrayFromResponse(string strResponse)
        {
            string[] aResponse = null;
            if (string.IsNullOrEmpty(strResponse) == false)
            {
                aResponse = strResponse.Split(' ');
            }
            return aResponse;
        }
		#endregion
	}
}
