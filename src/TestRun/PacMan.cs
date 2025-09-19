// Định nghĩa các trạng thái có thể có của Pac-Man
public enum PacManState
{
    Normal,     // Trạng thái bình thường
    Super,      // Trạng thái siêu năng lực sau khi ăn Power Pellet
    Dead        // Trạng thái bị Ghost bắt
}

// Class PacMan lưu trữ thông tin và hành vi của nhân vật chính
public class PacMan
{
    public int X { get; set; }              // Tọa độ ngang trên bản đồ
    public int Y { get; set; }              // Tọa độ dọc trên bản đồ
    public int Score { get; set; }          // Tổng điểm hiện tại của người chơi
    public PacManState State { get; set; }  // Trạng thái hiện tại của Pac-Man

    // Constructor khởi tạo vị trí ban đầu và trạng thái mặc định
    public PacMan(int x, int y)
    {
        X = x;                              // Gán tọa độ ngang
        Y = y;                              // Gán tọa độ dọc
        Score = 0;                          // Khởi tạo điểm số = 0
        State = PacManState.Normal;        // Trạng thái ban đầu là bình thường
    }

    // Phương thức di chuyển Pac-Man theo hướng dx, dy
    public void Move(int dx, int dy)
    {
        X += dx;                            // Cộng độ lệch vào tọa độ X
        Y += dy;                            // Cộng độ lệch vào tọa độ Y
    }

    // Phương thức cộng điểm khi ăn điểm hoặc Ghost
    public void AddScore(int points)
    {
        Score += points;                    // Cộng điểm vào tổng điểm
    }

    // Phương thức thay đổi trạng thái của Pac-Man
    public void ChangeState(PacManState newState)
    {
        State = newState;                   // Gán trạng thái mới
    }
}
