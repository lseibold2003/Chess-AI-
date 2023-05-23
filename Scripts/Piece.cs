namespace Chess {
    public class Piece {

        public const int None = 0;
        public const int King = 0b001;
        public const int Pawn = 0b010;
        public const int Knight = 0b011;
        public const int Bishop = 0b101;
        public const int Rook = 0b110;
        public const int Queen = 0b111;

        public const int WhitePiece = 0b01000;
        public const int BlackPiece = 0b10000;
        public const int ColorMask = 0b11000;

        public static int getColor(int piece) {
            return piece & ColorMask;
        }

        public static bool isColor(int piece, int color) {
            return (piece & ColorMask) == color;
        }

        public static int getPiece(int piece) {
            return piece & Queen; // Queen happens to coincide with what would be PieceMask (0b111)
        }

        public static bool isDiag(int piece) {
            return (piece & Bishop) == Bishop;
        }

        public static bool isStraight(int piece) {
            return (piece & Rook) == Rook;
        }

        public static isSliding(int piece) {
            return (piece & 0b100) == 0b100;
        }

    }
}