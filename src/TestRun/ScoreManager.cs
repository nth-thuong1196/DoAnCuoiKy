// Class ScoreManager chứa các hàm xử lý điểm số trong game
public static class ScoreManager
{
    // Hàm tính điểm mới bằng cách cộng thêm điểm vào điểm hiện tại
    public static void UpdateScore(out int score, int currentScore, int pointEarned)
    {
        score = currentScore + pointEarned; // Tính điểm mới bằng cách cộng thêm điểm
    }

    // Hàm xử lý khi Pac-Man ăn điểm tại vị trí hiện tại
    public static void UpdateScore(ref PacMan pacman, ref GameMap map)
    {
        int x = pacman.X; // Lấy tọa độ ngang của Pac-Man
        int y = pacman.Y; // Lấy tọa độ dọc của Pac-Man

        // Kiểm tra nếu đang ở trạng thái Super nhưng đã hết thời gian hiệu lực
        if (pacman.State == PacManState.Super &&
            (DateTime.Now - pacman.SuperStartTime).TotalMilliseconds > pacman.SuperDuration)
        {
            pacman.ChangeState(PacManState.Normal); // Hết hiệu lực → chuyển về trạng thái bình thường
        }

        char cell = map.GetCell(x, y); // Lấy ký hiệu ô hiện tại từ bản đồ

        // Trường hợp ăn điểm thường "."
        if (cell == '.')
        {
            map.SetCell(x, y, ' '); // Xóa ký hiệu "." khỏi bản đồ
            pacman.AddScore(1);     // Cộng 1 điểm vào điểm số Pac-Man
            Console.WriteLine($"Pac-Man ăn '.' → +1 điểm. Tổng điểm: {pacman.Score}");
        }

        // Trường hợp ăn Power Pellet "o"
        else if (cell == 'o')
        {
            map.SetCell(x, y, ' ');           // Xóa ký hiệu "o" khỏi bản đồ
            pacman.AddScore(5);               // Cộng 5 điểm
            pacman.ChangeState(PacManState.Super); // Chuyển trạng thái sang siêu năng lực
            pacman.SuperStartTime = DateTime.Now;  // Ghi nhận thời điểm bắt đầu siêu năng lực
            Console.WriteLine($"Pac-Man ăn 'o' → +5 điểm & trạng thái SUPER. Tổng điểm: {pacman.Score}");
        }

        // Trường hợp gặp Ghost "@"
        else if (cell == '@')
        {
            // Nếu Pac-Man đang ở trạng thái Super và còn trong thời gian hiệu lực
            if (pacman.State == PacManState.Super &&
                (DateTime.Now - pacman.SuperStartTime).TotalMilliseconds <= pacman.SuperDuration)
            {
                map.SetCell(x, y, ' '); // Xóa ký hiệu Ghost khỏi bản đồ
                pacman.AddScore(10);    // Cộng 10 điểm
                Console.WriteLine($"Pac-Man ăn '@' → +10 điểm. Tổng điểm: {pacman.Score}");
            }
            else
            {
                pacman.ChangeState(PacManState.Dead); // Nếu không có siêu năng lực → bị Ghost bắt
                Console.WriteLine("Pac-Man bị Ghost bắt! Trạng thái: DEAD");
            }
        }
    }
}
