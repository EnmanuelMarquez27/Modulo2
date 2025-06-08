using System;
using System.Collections.Generic;
using System.Linq;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }

    public Client(int id, string name, string lastName)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        RegistrationDate = DateTime.Now;
        IsActive = true; // By default, a new client is active
    }

    public void ShowDetails()
    {
        Console.WriteLine($"\n--- Client Details ---");
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Name: {Name} {LastName}");
        Console.WriteLine($"Registration Date: {RegistrationDate.ToShortDateString()}");
        Console.WriteLine($"Status: {(IsActive ? "Active" : "Inactive")}");
        Console.WriteLine($"----------------------");
    }
}

public class GymClientManager
{
    private List<Client> clients;
    private int nextClientId;

    public GymClientManager()
    {
        clients = new List<Client>();
        nextClientId = 1;
    }

    public void RegisterClient()
    {
        Console.WriteLine("\n--- Register New Client ---");
        Console.Write("Enter client's name: ");
        string name = Console.ReadLine();
        Console.Write("Enter client's last name: ");
        string lastName = Console.ReadLine();

        Client newClient = new Client(nextClientId, name, lastName);
        clients.Add(newClient);
        Console.WriteLine($"Client '{newClient.Name} {newClient.LastName}' registered successfully with ID: {newClient.Id}");
        nextClientId++;
    }

    public void ShowClientDetails()
    {
        Console.WriteLine("\n--- Show Client Details ---");
        Console.Write("Enter client ID: ");
        if (int.TryParse(Console.ReadLine(), out int clientId))
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                client.ShowDetails();
            }
            else
            {
                Console.WriteLine("Client not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
        }
    }

    public void ListClients()
    {
        Console.WriteLine("\n--- List of Clients ---");
        if (clients.Any())
        {
            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.Id}, Name: {client.Name} {client.LastName}, Status: {(client.IsActive ? "Active" : "Inactive")}");
            }
        }
        else
        {
            Console.WriteLine("No clients registered yet.");
        }
    }

    public void SearchClientByName()
    {
        Console.WriteLine("\n--- Search Client by Name ---");
        Console.Write("Enter client's name or last name to search: ");
        string searchTerm = Console.ReadLine().ToLower();

        var foundClients = clients.Where(c => c.Name.ToLower().Contains(searchTerm) || c.LastName.ToLower().Contains(searchTerm)).ToList();

        if (foundClients.Any())
        {
            Console.WriteLine("\n--- Found Clients ---");
            foreach (var client in foundClients)
            {
                client.ShowDetails();
            }
        }
        else
        {
            Console.WriteLine("No clients found with that name.");
        }
    }

    public void DeactivateClient()
    {
        Console.WriteLine("\n--- Deactivate Client ---");
        Console.Write("Enter client ID to deactivate: ");
        if (int.TryParse(Console.ReadLine(), out int clientId))
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                client.IsActive = false;
                Console.WriteLine($"Client '{client.Name} {client.LastName}' (ID: {client.Id}) has been deactivated.");
            }
            else
            {
                Console.WriteLine("Client not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
        }
    }

    public void ModifyClient()
    {
        Console.WriteLine("\n--- Modify Client ---");
        Console.Write("Enter client ID to modify: ");
        if (int.TryParse(Console.ReadLine(), out int clientId))
        {
            Client client = clients.FirstOrDefault(c => c.Id == clientId);
            if (client != null)
            {
                Console.WriteLine($"Modifying client: {client.Name} {client.LastName}");
                Console.Write($"Enter new name (current: {client.Name}): ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    client.Name = newName;
                }

                Console.Write($"Enter new last name (current: {client.LastName}): ");
                string newLastName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newLastName))
                {
                    client.LastName = newLastName;
                }

                Console.Write($"Set client as active (yes/no, current: {(client.IsActive ? "yes" : "no")}): ");
                string statusInput = Console.ReadLine().ToLower();
                if (statusInput == "yes")
                {
                    client.IsActive = true;
                }
                else if (statusInput == "no")
                {
                    client.IsActive = false;
                }

                Console.WriteLine("Client modified successfully.");
                client.ShowDetails();
            }
            else
            {
                Console.WriteLine("Client not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        GymClientManager manager = new GymClientManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n======================================");
            Console.WriteLine("*** Gym Client Registration System ***");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Register a client");
            Console.WriteLine("2. Show client details");
            Console.WriteLine("3. List clients");
            Console.WriteLine("4. Search client (Name)");
            Console.WriteLine("5. Deactivate a client");
            Console.WriteLine("6. Modify a client");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.RegisterClient();
                    break;
                case "2":
                    manager.ShowClientDetails();
                    break;
                case "3":
                    manager.ListClients();
                    break;
                case "4":
                    manager.SearchClientByName();
                    break;
                case "5":
                    manager.DeactivateClient();
                    break;
                case "6":
                    manager.ModifyClient();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Exiting program. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}