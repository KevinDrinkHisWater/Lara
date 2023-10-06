using System;
using System.Data;
using System.Data.SqlClient;

namespace TestProgrammation
{

	/// <summary>
	/// Gets the details of Users.
	/// </summary>
	public class UserDataProvider
	{

		/// <summary>
		/// Gets a string of user details.
		/// Uses the format "UserID:FirstName LastName:Email", each entry separated by "-".
		/// </summary>
		/// <param name="maximum">The maximum amount of users to return</param>
		/// <param name="usersCount">The count of users returned</param>
		/// <returns>The formated string</returns>
		public string GetUsersData(int clientId, int maximum, out int usersCount)
        {
            try
            {
                DataSet dataSet = GetDataOnUser(clientId, maximum);

                string result = "";
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    result += dataSet.Tables[0].Rows[i]["UserID"] + ";";
                    result += dataSet.Tables[0].Rows[i]["FirstName"] + ":" + dataSet.Tables[0].Rows[i]["LastName"] + ";";
                    result += dataSet.Tables[0].Rows[i]["Email"] + ";";
                }

                usersCount = result.Split('-').Length;
                if (result == "")
                {
                    return "-";
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                usersCount = 0;
                return string.Empty;
            }
            
        }

        private static DataSet GetDataOnUser(int clientId, int maximum)
        {
            using (SqlConnection connection = new SqlConnection("my_fake_connection_string"))
            {
                string query = "SELECT TOP @Maximum";
                query += "U.UserID, U.FirstName, U.LastName, U.Email, ";
                query += "FROM Users U ";
                query += "INNER JOIN Clients C ON C.ClientID = ClientID ";
                query += "WHERE C.ClientID = @ClientID ";


                SqlCommand command = new SqlCommand(query, connection);
                command.CommandText = query;
                command.Parameters.Add("@ClientID", System.Data.SqlDbType.BigInt).Value = clientId;
                command.Parameters.Add("@Maximum", System.Data.SqlDbType.Int).Value = maximum;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                return dataSet;
            }
        }
    }

}