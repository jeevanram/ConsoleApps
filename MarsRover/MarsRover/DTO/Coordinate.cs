namespace MarsRover.DTO
{
    public class Coordinate
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Coordinate()
        {
            this.PosX = 0;
            this.PosY = 0;
        }

        public Coordinate(int posX, int posY)
        {
            this.PosX = posX;
            this.PosY = posY;
        }
    }
}