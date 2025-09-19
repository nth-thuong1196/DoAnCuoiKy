// Định nghĩa các trạng thái của Ghost
public enum GhostState
{
    Normal,        // Di chuyển bình thường
    Frightened,    // Trạng thái sợ hãi khi Pac-Man có siêu năng lực
    Eaten          // Bị Pac-Man ăn, quay về nhà
}

// Class Ghost lưu trữ thông tin và hành vi của mỗi Ghost
public class Ghost
{
    public int X { get; set; }              // Tọa độ ngang
    public int Y { get; set; }              // Tọa độ dọc
    public GhostState State { get; set; }   // Trạng thái hiện tại
    public string Color { get; set; }       // Màu sắc để phân biệt Ghost

    // Constructor khởi tạo vị trí và màu sắc
    public Ghost(int x, int y, string color)
    {
        X = x;                              // Gán tọa độ ngang
        Y = y;                              // Gán tọa độ dọc
        Color = color;                      // Gán màu sắc
        State = GhostState.Normal;          // Trạng thái mặc định là bình thường
    }

    // Phương thức di chuyển Ghost
    public void Move(int dx, int dy)
    {
        X += dx;                            // Cập nhật tọa độ X
        Y += dy;                            // Cập nhật tọa độ Y
    }

    // Phương thức thay đổi trạng thái Ghost
    public void ChangeState(GhostState newState)
    {
        State = newState;                   // Gán trạng thái mới
    }
}
