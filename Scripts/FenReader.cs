using System.Collections;

namespace Chess {
    public static class FenReader {

        public const string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        static Dictionary<char, int> pieces = new Dictionary<char, int>() {
            ['p'] = Piece.Pawn, ['n'] = Piece.Knight, ['b'] = Piece.Bishop, ['r'] = Piece.Rook, ['q'] = Piece.Queen, ['k'] = Piece.King
        };

        public struct BoardState {
            int[] board;
            bool WQCastle;
            bool WKCastle;
            bool BQCastle;
            bool BKCastle;
            bool blackCastle;
            int moves;
            bool whiteTurn;
        };

        public static BoardState readFen(string fen) {
            int[64] b;
            int pos = 0;
            string[] split = fen.Split(' ');
            for (char c : split[0]) {
                if (c == '/') {
                    continue;
                }
                if (char.IsDigit(c)) {
                    pos+= (int) char.GetNumericValue(c);
                } else {
                    int piece = pieces[char.ToLower(c)];
                    int color = (char.IsUpper(c)) ? Piece.WhitePiece : Piece.BlackPiece;
                    b[pos] = piece | color;
                }
            }

        }

    }
}