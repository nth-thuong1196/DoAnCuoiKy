// Class GameMap lưu trữ thông tin bản đồ và các phương thức xử lý
public class GameMap
{
    public int Width { get; private set; }     // Chiều rộng bản đồ
    public int Height { get; private set; }    // Chiều cao bản đồ
    public char[,] Grid { get; private set; }  // Mảng 2 chiều lưu ký hiệu ô

    // Constructor khởi tạo kích thước và mảng bản đồ
    public GameMap(int width, int height)
    {
        Width = width;                         // Gán chiều rộng
        Height = height;                       // Gán chiều cao
        Grid = new char[height, width];        // Tạo mảng 2 chiều (hàng trước, cột sau)
    }

    // Gán ký hiệu cho ô tại vị trí (x, y)
    public void SetCell(int x, int y, char symbol)
    {
        if (IsValidPosition(x, y))             // Kiểm tra vị trí hợp lệ
            Grid[y, x] = symbol;               // Gán ký hiệu vào ô
    }

    // Lấy ký hiệu ô tại vị trí (x, y)
    public char GetCell(int x, int y)
    {
        return IsValidPosition(x, y) ? Grid[y, x] : ' '; // Trả về ký hiệu hoặc khoảng trắng nếu sai vị trí
    }

    // Kiểm tra ô có phải là tường không
    public bool IsWall(int x, int y)
    {
        return GetCell(x, y) == '#';           // Trả về true nếu ô là tường
    }

    // Kiểm tra vị trí có nằm trong bản đồ không
    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height; // Kiểm tra tọa độ hợp lệ
    }
}
