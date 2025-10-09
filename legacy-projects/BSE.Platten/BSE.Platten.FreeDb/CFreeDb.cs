using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using BSE.Platten.BO;
using System.Globalization;

namespace BSE.Platten.FreeDb
{
	/// <summary>
	/// Zusammenfassung für CFreeDb.
	/// </summary>
	public class CFreeDb
	{
		#region Enumerationen
		
		public enum MatchCode
		{
			MatchNone,
			MatchMultiple,
			MatchExact
		}
		
		#endregion

		#region Konstanten
		
		private const string m_strPreRequestURL = "http://freedb.freedb.org/~cddb/cddb.cgi/?cmd=";
		private const string m_strProtocol = "proto=6";
		
		#endregion

		#region FieldsPrivate
		
		private CAlbum m_album;
		private MatchCode m_eMatchCode;
		
		#endregion
		
		#region Properties
		#endregion

		#region MethodsPublic

		public CFreeDb()
		{
			this.m_album = new CAlbum();
		}

		public BSE.Platten.BO.CAlbum GetMediaDataForCD(string strDiskId)
		{
			try
			{
				ArrayList arrayListFreeDbResponse = GetBaseResponseFromFreeDb(strDiskId);
				if (arrayListFreeDbResponse.Count > 0)
				{
					m_eMatchCode = GetMatchCode(arrayListFreeDbResponse);
					switch (m_eMatchCode)
					{
						case MatchCode.MatchNone:
							throw new BSE.Platten.FreeDb.FreeDBMatchNoneException(m_album.ErrorText);		
						case MatchCode.MatchExact:
							GetDataFromFreeDb();
							break;
						case MatchCode.MatchMultiple:
							GetSelectedAlbumFromFreeDb(arrayListFreeDbResponse);
							break;
					}
				}
				return this.m_album;
			}
			catch (Exception)
			{
				throw;
			}
		}

		#endregion

		#region MethodsPrivate

		private ArrayList GetBaseResponseFromFreeDb(string strDiskId)
		{
			ArrayList arrayListFreeDbResponse = null;
			string strQueryRequestURL = "cddb+query+" + strDiskId;
			try
			{
				arrayListFreeDbResponse = GetFreeDbWebClientResponse(m_strPreRequestURL + strQueryRequestURL + GetPostRequestURL());
				return arrayListFreeDbResponse;
			}
			catch (System.Net.WebException)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private static ArrayList GetFreeDbWebClientResponse(string strRequestUrl)
		{
			StreamReader streamReader = null;
			ArrayList arrayListFreeDbResponse = null;
			WebClient webClient = null;
			try
			{
				arrayListFreeDbResponse = new ArrayList();
				webClient = new WebClient();
				Stream stream = webClient.OpenRead(strRequestUrl);
				streamReader = new StreamReader(stream);

				string strResponseLine;

				while ( (strResponseLine = streamReader.ReadLine()) != null)
				{
					arrayListFreeDbResponse.Add(strResponseLine);
				}
				return arrayListFreeDbResponse;
			}
			catch (System.Net.WebException)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (streamReader != null)
				{
					streamReader.Close();
				}
			}
		}

		private MatchCode GetMatchCode(ArrayList arrayListFreeDbResponse)
		{
			MatchCode matchCode = MatchCode.MatchNone;
			switch (int.Parse(arrayListFreeDbResponse[0].ToString().Substring(0,3)))
			{
				case 200:
					//exact match, read details
					matchCode = MatchCode.MatchExact;
					//get genre
					this.m_album.Genre = arrayListFreeDbResponse[0].ToString().Substring(4,arrayListFreeDbResponse[0].ToString().IndexOf(" ",4)-4);
					this.m_album.MediaId = arrayListFreeDbResponse[0].ToString().Substring(5 + m_album.Genre.Length,8);
					break;
				case 202:
					//couldn't find CD-ID from CDDB "cddb query" command
					matchCode = MatchCode.MatchNone;
					this.m_album.ErrorText = arrayListFreeDbResponse[0].ToString();
					break;
				case 210:
				case 211:
					matchCode = MatchCode.MatchMultiple;
					break;
			}

			return matchCode;
		}

		private void GetDataFromFreeDb()
		{
			ArrayList arrayList = null;
			string  strQueryRequestURL = "cddb+read+" + this.m_album.Genre + "+" + this.m_album.MediaId;
			try
			{
				arrayList = GetFreeDbWebClientResponse(m_strPreRequestURL + strQueryRequestURL + GetPostRequestURL());
				if (arrayList.Count > 0)
				{
					ParseCDInformationFromFreeDb(arrayList);
				}
			}
			catch (System.Net.WebException)
			{
				throw;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void ParseCDInformationFromFreeDb(ArrayList arrayListFreeDbResponse)
		{
			int iTrackIndex = 1;
			ArrayList currentTracks = new ArrayList();
			switch (int.Parse(arrayListFreeDbResponse[0].ToString().Substring(0,3)))
			{
				case 210:
					for (int i=0;i < arrayListFreeDbResponse.Count; i++)
					{
						if (arrayListFreeDbResponse[i].ToString() == ".")
						{
							break;
						}
						//year info
						int iYear = arrayListFreeDbResponse[i].ToString().IndexOf("DYEAR=");

						if (iYear != -1)
						{
							if (arrayListFreeDbResponse[i].ToString().Length > 6)
							{
								this.m_album.Year = int.Parse(arrayListFreeDbResponse[i].ToString().Substring(iYear + 6,4).ToString());
							}
							else
							{
								this.m_album.Year = 0;
							}
						}
						//genre info
						int iGenre = arrayListFreeDbResponse[i].ToString().IndexOf("DGENRE=",0);

						if (iGenre != -1)
						{
							this.m_album.Genre = arrayListFreeDbResponse[i].ToString().Substring(iGenre + 7,arrayListFreeDbResponse[i].ToString().Length - 7).ToString();
						}
						//artist/album info
						int iArtistInfo = arrayListFreeDbResponse[i].ToString().IndexOf("DTITLE=",0);
						
						if (iArtistInfo != -1)
						{
							string strTmp = arrayListFreeDbResponse[i].ToString().Substring(7,arrayListFreeDbResponse[i].ToString().Length - 7);
                            if (string.IsNullOrEmpty(strTmp) == false)
                            {
                                Regex regArr = new Regex(" / ");
                                string[] arrTmp = regArr.Split(strTmp);
                                if ((arrTmp != null) && (arrTmp.Length > 0))
                                {
                                    this.m_album.Interpret = arrTmp[0];
                                    if (arrTmp.Length == 2)
                                    {
                                        this.m_album.Title = arrTmp[1];
                                    }
                                }
                            }
						}
						//Track titles
						int iTitelInfo = arrayListFreeDbResponse[i].ToString().IndexOf("TTITLE",0);

						if (iTitelInfo != -1)
						{
							int iTmp = arrayListFreeDbResponse[i].ToString().IndexOf("=") + 1;
							CTrack track = new CTrack();
							track.TrackNumber = iTrackIndex;
							track.Title = arrayListFreeDbResponse[i].ToString().Substring(iTmp,arrayListFreeDbResponse[i].ToString().Length - iTmp).Trim();
							currentTracks.Add(track);
							iTrackIndex++;
						}
					}
					if (this.m_album.Tracks == null)
					{
						this.m_album.Tracks = new CTrack[currentTracks.Count];
					}
					currentTracks.CopyTo(this.m_album.Tracks);
					break;
			}
		}
		
		private void GetSelectedAlbumFromFreeDb(ArrayList arrayListFreeDbResponse)
		{
            try
            {
                using (SelectCD frmSelectCD = new SelectCD(arrayListFreeDbResponse))
                {
                    Form parentForm = frmSelectCD.FindForm();
                    if (parentForm != null)
                    {
                        frmSelectCD.StartPosition = FormStartPosition.CenterParent;
                    }

                    if (frmSelectCD.ShowDialog() == DialogResult.OK)
                    {
                        string strSelectedCD = frmSelectCD.SelectedCD;
                        if (string.IsNullOrEmpty(strSelectedCD) == false)
                        {
                            this.m_album.Genre = strSelectedCD.Substring(0, strSelectedCD.IndexOf(" "));
                            this.m_album.MediaId = strSelectedCD.Substring(this.m_album.Genre.Length + 1, 8);
                            GetDataFromFreeDb();
                        }
                    }
                    else
                    {
                        this.m_album = null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

		}

		private string GetPostRequestURL()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("&");
			stringBuilder.Append(GetHello());
			stringBuilder.Append("+");
			stringBuilder.Append(GetAssemblyName());
			stringBuilder.Append("+1&");
			stringBuilder.Append(m_strProtocol);
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

		private static string GetHello()
		{
			string strHello = "hello=uwe+messe.ch";
			return strHello;
		}

		#endregion
	}
}
