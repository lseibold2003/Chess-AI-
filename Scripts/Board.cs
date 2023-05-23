namespace Chess {
    public class Board {

        static Dictionary<int, int> pieceValues = new Dictionary<int, int>() {
            0 = 0, 
            Piece.WhitePiece | Piece.Pawn = 1, Piece.WhitePiece | Piece.Knight = 3, Piece.WhitePiece | Piece.Bishop = 3, Piece.WhitePiece | Piece.Rook = 5, Piece.WhitePiece | Piece.Queen = 8, Piece.WhitePiece | Piece.King = 1000,
            Piece.BlackPiece | Piece.Pawn = -1, Piece.BlackPiece | Piece.Knight = -3, Piece.BlackPiece | Piece.Bishop = -3, Piece.BlackPiece | Piece.Rook = -5, Piece.BlackPiece | Piece.Queen = -8, Piece.BlackPiece | Piece.King = -1000,
        };

        public static int evalBoard(BoardState state) {
            int ans = 0;
            for (int i : state.board) {
                ans+=pieceValues[i];
            }
            return ans;
        }

    }
}