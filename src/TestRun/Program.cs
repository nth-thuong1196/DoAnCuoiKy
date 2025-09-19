using System; 

class Program
{
    // Hàm Main là điểm bắt đầu khi chạy chương trình
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // ============================
        // Khởi tạo đối tượng Pac-Man
        // ============================
        PacMan pacman = new PacMan(1, 1);         // Tạo Pac-Man tại vị trí (1,1)
        pacman.AddScore(10);                      // Ăn điểm thường
        pacman.ChangeState(PacManState.Super);    // Đổi trạng thái sang siêu năng lực

        // In thông tin Pac-Man ra màn hình
        Console.WriteLine("=== Pac-Man ===");
        Console.WriteLine($"Vị trí: ({pacman.X}, {pacman.Y})");
        Console.WriteLine($"Điểm: {pacman.Score}");
        Console.WriteLine($"Trạng thái: {pacman.State}");

        // ============================
        // Khởi tạo đối tượng Ghost
        // ============================
        Ghost ghost = new Ghost(2, 2, "Red");      // Tạo Ghost màu đỏ tại (2,2)
        ghost.ChangeState(GhostState.Frightened); // Ghost chuyển sang trạng thái sợ hãi

        // In thông tin Ghost ra màn hình
        Console.WriteLine("\n=== Ghost ===");
        Console.WriteLine($"Vị trí: ({ghost.X}, {ghost.Y})");
        Console.WriteLine($"Màu: {ghost.Color}");
        Console.WriteLine($"Trạng thái: {ghost.State}");

        // ============================
        // Khởi tạo bản đồ đơn giản
        // ============================
        GameMap map = new GameMap(5, 5);           // Tạo bản đồ 5x5
        map.SetCell(1, 1, '.');                    // Đặt điểm thường tại (1,1)
        map.SetCell(2, 2, '#');                    // Đặt tường tại (2,2)
        map.SetCell(3, 3, 'o');                    // Đặt Power Pellet tại (3,3)

        // In bản đồ ra màn hình
        Console.WriteLine("\n=== Bản đồ ===");
        for (int y = 0; y < map.Height; y++)       // Duyệt từng hàng
        {
            for (int x = 0; x < map.Width; x++)    // Duyệt từng cột
            {
                Console.Write(map.GetCell(x, y));  // In ký hiệu ô
            }
            Console.WriteLine();                   // Xuống dòng sau mỗi hàng
        }
    }
}
