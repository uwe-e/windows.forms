using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.FreeDb
{
    internal static class Constants
    {
        public static string KeyYear
        {
            get { return "DYEAR="; }
        }
        public static string KeyGenre
        {
            get { return "DGENRE="; }
        }
        public static string KeyArtistInfo
        {
            get { return "DTITLE="; }
        }
        public static string KeyTitles
        {
            get { return "TTITLE"; }
        }
        public static char[] ArtistInfoDelimiter
        {
            get { return new Char[]{'/'}; }
        }
        public static string PreRequestURL
        {
            //FreeDb has switched off
            //get { return "http://freedb.freedb.org/~cddb/cddb.cgi/?cmd="; }
            get { return "http://gnudb.gnudb.org/~cddb/cddb.cgi/?cmd="; }
        }
        public static string Protocol
        {
            get { return "proto=6"; }
        }
        public static string Hello
        {
            get { return "hello=uwe+bsetunes.com"; }
        }
    }
}
