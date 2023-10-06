using System;

namespace TestProgrammation
{

	/// <summary>
	/// Test de programmation.
	/// </summary>
	static class Program
	{

		/// <summary>
		/// Entry point.
		/// </summary>
		static void Main(string[] args)
		{
            try
            {
                // Exercice 1
                UserDataProvider dataProvider = new UserDataProvider();
                string userDetails = dataProvider.GetUsersData(34, 100, out int usersCount);
                Console.WriteLine($"Users details: {userDetails} (Count: {usersCount})");

                // Exercice 2
                PasswordGenerator generator = new PasswordGenerator();
				string password = generator.Generate(10, true);
				Console.WriteLine($"Password generated: {password}");
			} catch (Exception ex)
            {
				Console.WriteLine(ex.Message);
            }
			

			// Exercice 3
			/* Mise en situation:
			 * Vous devez récupérer les entrées de la table Users. La table contient un million d'entrées.
			 * Deux options s'offrent à vous pour récupérer le nom d'un utilisateur:
			 * a) SELECT CONCAT(FirstName, ' ', LastName) FROM Users
			 * b) SELECT FirstName, LastName FROM Users (et concaténer les données côté serveur ou client)
			 * Quelle sera votre solution? Expliquez votre réponse plus bas:
			 */
			/*
			 * Choix : B
			 * Le traitement des informations d'une requête doit se traiter côté serveur puisque le client n'as pas nécéssairement les capacités pour faire le traitement.
			 * De plus, tout traitement de données doit se faire côté client pour éviter d'envoyer du data inutile à la requête et ainsi d'éviter d'allourdir la data retourner.
			 * 
			 */
		}

	}

}