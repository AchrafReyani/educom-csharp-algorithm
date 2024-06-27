using BornToMove;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Het is tijd om te bewegen!");

        while (true)
        {
            Console.WriteLine("Wil je een bewegingssuggestie (1) of uit de lijst kiezen (2)? Of typ 'exit' om af te sluiten.");
            string keuze = Console.ReadLine();

            if (keuze.ToLower() == "exit")
                break;

            switch (keuze)
            {
                case "1":
                    SuggestMove();
                    break;
                case "2":
                    ChooseMove();
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze, probeer opnieuw.");
                    break;
            }
        }
    }

    static void SuggestMove()
    {
        using (var context = new MoveContext())
        {
            var moveIds = context.Moves.Select(m => m.Id).ToList();
            var random = new Random();
            int randomId = moveIds[random.Next(moveIds.Count)];

            var move = context.Moves.Find(randomId);
            DisplayMove(move);

            RateMove();
        }
    }

    static void ChooseMove()
    {
        using (var context = new MoveContext())
        {
            var moves = context.Moves.Select(m => new { m.Id, m.Name, m.SweatRate }).ToList();

            for (int i = 0; i < moves.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {moves[i].Name} - SweatRate: {moves[i].SweatRate}");
            }

            Console.WriteLine("Kies een beweging door het nummer in te voeren, of typ '0' om een nieuwe beweging toe te voegen.");
            int keuze = int.Parse(Console.ReadLine());

            if (keuze == 0)
            {
                AddNewMove();
            }
            else
            {
                var selectedMove = context.Moves.Find(moves[keuze - 1].Id);
                DisplayMove(selectedMove);

                RateMove();
            }
        }
    }

    static void AddNewMove()
    {
        using (var context = new MoveContext())
        {
            Console.WriteLine("Voer de naam van de nieuwe beweging in:");
            string name = Console.ReadLine();

            if (context.Moves.Any(m => m.Name == name))
            {
                Console.WriteLine("Deze beweging bestaat al.");
                return;
            }

            Console.WriteLine("Voer de beschrijving in:");
            string description = Console.ReadLine();

            Console.WriteLine("Voer de sweatRate in:");
            float sweatRate = float.Parse(Console.ReadLine());

            var newMove = new Move
            {
                Name = name,
                Description = description,
                SweatRate = sweatRate
            };

            context.Moves.Add(newMove);
            context.SaveChanges();

            Console.WriteLine("Nieuwe beweging toegevoegd.");
        }
    }

    static void DisplayMove(Move move)
    {
        Console.WriteLine($"Naam: {move.Name}");
        Console.WriteLine($"Beschrijving: {move.Description}");
        Console.WriteLine($"SweatRate: {move.SweatRate}");
    }

    static void RateMove()
    {
        Console.WriteLine("Geef een beoordeling van 1-5:");
        int rating = int.Parse(Console.ReadLine());

        Console.WriteLine("Geef een intensiteit van 1-5:");
        int intensity = int.Parse(Console.ReadLine());

        Console.WriteLine("Bedankt voor je feedback!");
    }
}
