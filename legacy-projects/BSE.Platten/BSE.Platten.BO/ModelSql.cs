using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;

namespace BSE.Platten.BO
{
    public class ModelSql
    {
        #region MethodsPublic
        /// <overloads>
        /// Gets the value of the specified column as a Boolean.
        /// </overloads>
        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="bDefault">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist kein 'Bit'. Die Exception wird
        /// von der Funktion <see cref="System.Data.IDataRecord.GetBoolean"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataRecord"/> = <b>null</b>).
        /// </exception>
        public static bool GetBoolean(IDataRecord dataReader, string strFieldName, bool bNullAllowed, bool bDefault)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetBoolean Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return bDefault;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetBoolean Field '{0}' is null.", strFieldName));
                }
            }
            else if (obj is bool)
            {
                return (bool)obj;
            }
            else
            {
                try
                {
                    return Convert.ToBoolean(obj);
                }
                catch (FormatException)
                {
                    throw new FormatException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetBoolean Field '{0}'", strFieldName));
                }
            }
        }
        /// <overloads>
        /// Reads a stream of bytes from the specified column into the buffer as an array.
        /// </overloads>
        /// <summary>
        /// Reads a stream of bytes from the specified column into the buffer as an array.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="arbyteDefault">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist nicht vom korrekten Typ. Die Exception wird
        /// von der Funktion <see cref="System.Data.DBDataReader.GetBytes"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataReader"/> = <b>null</b>).
        /// </exception>
        public static byte[] GetBytes(IDataRecord dataReader, string strFieldName, bool bNullAllowed, byte[] arbyteDefault)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetBytes Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return arbyteDefault;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetBytes Field '{0}' is null.", strFieldName));
                }
            }
            else
            {
                byte[] arb = obj as byte[];
                if (arb != null)
                {
                    return arb;
                }
            }
            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetBytes Field '{0}'", strFieldName));
        }
        /// <overloads>
        /// Gets the date and time data value of the spcified field.
        /// </overloads>
        /// <summary>
        /// Gets the date and time data value of the spcified field.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="dtDefault">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist kein 'datetime' resp. 'smalldatetime'. Die Exception wird
        /// von der Funktion <see cref="System.Data.DBDataReader.GetDateTime"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataReader"/> = <b>null</b>).
        /// </exception>
        public static DateTime GetDateTime(IDataRecord dataReader, string strFieldName, bool bNullAllowed, DateTime dtDefault)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetDateTime Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return dtDefault;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetDateTime Field '{0}' is null.", strFieldName));
                }
            }
            else if (obj is DateTime)
            {
                return (DateTime)obj;
            }
            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetDateTime Field '{0}'", strFieldName));
        }
        public static TimeSpan GetTimeSpan(IDataRecord dataReader, string strFieldName, bool bNullAllowed, TimeSpan tsDefault)
        {
            DateTime dateTime = GetDateTime(dataReader, strFieldName, bNullAllowed, new DateTime());
            if (dateTime != null)
            {
                return new TimeSpan(
                    dateTime.Hour,
                    dateTime.Minute,
                    dateTime.Second);
            }
            return new TimeSpan(0,0,0);
        }
        /// <overloads>
        /// Returns the guid value of the specified field.
        /// </overloads>
        /// <summary>
        /// Returns the guid value of the specified field.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="defaultGuid">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist kein 'uniqueidentifier'. Die Exception wird
        /// von der Funktion <see cref="System.Data.IDataRecord.GetGuid"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataReader"/> = <b>null</b>).
        /// </exception>
        public static Guid GetGuid(IDataRecord dataReader, string strFieldName, bool bNullAllowed, Guid defaultGuid)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetGuid Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return defaultGuid;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetGuid Field '{0}' is null.", strFieldName));
                }
            }
            else if (obj is Guid)
            {
                return (Guid)obj;
            }
            else if (obj is string)
            {
                try
                {
                    return new Guid((string)obj);
                }
                catch (FormatException)
                {
                    throw new FormatException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetGuid Field '{0}'", strFieldName));
                }
            }
            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetGuid Field '{0}'", strFieldName));
        }
        /// <overloads>
        /// Gets the 32-bit signed integer value of the specified field.
        /// </overloads>
        /// <summary>
        /// Gets the 32-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="iDefault">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist kein 'int'. Die Exception wird
        /// von der Funktion <see cref="System.Data.DBDataReader.GetInt32"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataReader"/> = <b>null</b>).
        /// </exception>
        public static int GetInt32(IDataRecord dataReader, string strFieldName, bool bNullAllowed, int iDefault)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetInt32 Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return iDefault;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetInt32 Field '{0}' is null.", strFieldName));
                }
            }
            else if (obj is int)
            {
                return (int)obj;
            }
            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetInt32 Field '{0}'", strFieldName));
        }
        /// <overloads>
        /// Gets the 64-bit signed integer value of the specified field.
        /// </overloads>
        /// <summary>
        /// Gets the 64-bit signed integer value of the specified field.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="lDefault">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist kein 'bigint'. Die Exception wird
        /// von der Funktion <see cref="System.Data.IDataRecord.GetInt64"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataReader"/> = <b>null</b>).
        /// </exception>
        public static long GetInt64(IDataRecord dataReader, string strFieldName, bool bNullAllowed, long lDefault)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetInt64 Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return lDefault;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetInt64 Field '{0}' is null.", strFieldName));
                }
            }
            else if (obj is long)
            {
                return (long)obj;
            }
            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetInt64 Field '{0}'", strFieldName));
        }
        /// <overloads>
        /// Gets the string value of the specified field.
        /// </overloads>
        /// <summary>
        /// Gets the string value of the specified field.
        /// </summary>
        /// <param name="dataReader">Dieser Parameter beinhaltet den Record, aus dem die Daten gelesen werden.</param>
        /// <param name="strFieldName">Name des Feldes aus dem gelesen werden soll.</param>
        /// <param name="bNullAllowed">Soll Null auf dem Feld erlaubt sein?</param>
        /// <param name="strDefault">
        /// Defaultwert, falls null auf der Datenbank steht und <paramref name="bNullAllowed"/> == true.
        /// </param>
        /// <returns>Wert von der Datenbank oder Defaultwert.</returns>
        /// <exception cref="System.IndexOutOfRangeException">
        /// Falls der Feldname nicht existiert, wird diese Exception geworfen.<br/>
        /// No column with the specified name was found.
        /// </exception>
        /// <exception cref="System.InvalidCastException">
        /// Das Feld auf der Datenbank ist kein 'varchar', 'char', 'sysname', 'nchar', 'nchar', 'ntext', 'nvarchar'
        /// resp. 'text'. Die Exception wird von der Funktion <see cref="System.Data.DBDataReader.GetString"/> geworfen.
        /// The specified cast is not valid.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// Das Feld ist Null, obwohl es nicht null sein sollte 
        /// (Parameter der Funktion <paramref name="bNullAllowed"/> = <b>false</b>).
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Parameter der Funktion <paramref name="dataReader"/> = <b>null</b>).
        /// </exception>
        public static string GetString(IDataRecord dataReader, string strFieldName, bool bNullAllowed, string strDefault)
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException("dataReader",
                    string.Format(CultureInfo.InvariantCulture,"ModelSql.GetString Field '{0}'", strFieldName));
            }
            object obj = dataReader[strFieldName];
            if (obj is System.DBNull)
            {
                if (bNullAllowed == true)
                {
                    return strDefault;
                }
                else
                {
                    throw new ArgumentException("bNullAllowed",
                        string.Format(CultureInfo.InvariantCulture,"ModelSql.GetString Field '{0}' is null.", strFieldName));
                }
            }
            else
            {
                string item = obj as string;
                if (item != null)
                {
                    return item;
                }
            }
            throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,"ModelSql.GetString Field '{0}'", strFieldName));
        }
        #endregion
    }
}
