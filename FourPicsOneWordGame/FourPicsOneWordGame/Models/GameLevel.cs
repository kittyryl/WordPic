namespace FourPicsOneWordGame.Models
{
    public class GameLevel
    {
        public int GameLevelId { get; set; } 
        public string CorrectWord { get; set; } = string.Empty;
        public string ImagePath1 { get; set; } = string.Empty;  
        public string ImagePath2 { get; set; } = string.Empty; 
        public string ImagePath3 { get; set; } = string.Empty;  
        public string ImagePath4 { get; set; } = string.Empty; 

    }
}