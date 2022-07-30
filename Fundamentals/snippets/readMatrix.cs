        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        var matrix = new int[rows, cols];
        
        for (int r = 0; r < rows; r++)
        {
            var rowElements = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int c = 0; c < cols; c++)
            {
                matrix[r, c] = rowElements[c]; 
            }            
        }
