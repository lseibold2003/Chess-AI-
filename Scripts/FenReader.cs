using System.Collections;

namespace Chess {
    public static class FenReader {

        public const string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

        static Dictionary<char, int> pieces = new Dictionary<char, int>() {
            ['p'] = Piece.Pawn, ['n'] = Piece.Knight, ['b'] = Piece.Bishop, ['r'] = Piece.Rook, ['q'] = Piece.Queen, ['k'] = Piece.King
        };

        public struct BoardState {
            int[] board;
            bool WQCastle = false;
            bool WKCastle = false;
            bool BQCastle = false;
            bool BKCastle = false;
            bool whiteTurn;
            int PassantFile = -10;
            int moves;
        };

        public static BoardState readFen(string fen) {
            int[] b = new int[64];
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
            BoardState ans;
            ans.board = b;
            ans.whiteTurn = (split[1] == 'w');
            for (char c : split[2]) {
                if (c == 'K') {
                    ans.WKCastle = true;
                } else if (c == 'Q') {
                    ans.WQCastle = true;
                } else if (c == 'k') {
                    ans.BKCastle = true;
                } else if (c == 'q') {
                    ans.BQCastle = true;
                }
            }
            if (split[3] != '-') {
                ans.PassantFile = (int) char.GetNumericValue(split[3][1]);
            }
            ans.moves = (int) char.GetNumericValue(split[4]);
        }

    }
}