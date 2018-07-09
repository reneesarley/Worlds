using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace World.Models
{
    public class Country
    {
        private string _code;
        private string _name;
        private static object _choice;
        public static object Choice2;

        public Country(string countryCode, string countryName)
        {
            _code = countryCode;
            _name = countryName;
           
        }

        public string GetCode(){
            return _code;
        }

        public String GetName(){
            return _name;
        }

        public static void SetChoice(object choice){
            _choice = choice;
        }

        public object GetChoice(){
            return _choice;
        }


        public static List<Country> GetAll()
        {
            List<Country> allCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                Country newCountry = new Country(countryCode, countryName);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }

        public static List<string> AllColumnsList()
        {
            List<string> allColumns = new List<string> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DESCRIBE country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string column = rdr.GetString(0);


                //Country newCountry = new Country(countryCode, countryName);
                allColumns.Add(column);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allColumns;
        }


        public static List<object> AllResults(object selection)
        {
            List<object> allColumns = new List<object> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT DISTINCT " + selection + " FROM country;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                object column = rdr[0];
                allColumns.Add(column);

            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allColumns;
        }

        public static List<Country> GetSelected(string column, string value)
        {
            List<Country> allSelectedCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE " + column + "=" + value + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                Country newCountry = new Country(countryCode, countryName);
                allSelectedCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSelectedCountries;
        }

        public static List<Country> FilterSelected(object value)
        {
            List<Country> allSelectedCountries = new List<Country> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM country WHERE " + _choice + "=" + "'" + value + "'" + ";";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                string countryCode = rdr.GetString(0);
                string countryName = rdr.GetString(1);
                Country newCountry = new Country(countryCode, countryName);
                allSelectedCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSelectedCountries;
        }
    }
}
