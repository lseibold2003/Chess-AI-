using System.Collections;

namespace Chess {
    public class MoveGeneration {
        
        public List<Move> pawnMoves(int square, BoardState curBoard) {
            int dir = 1;
            int curFile = square % 8
            if (Piece.isColor(curBoard.board[square], Piece.BlackPiece)) {
                dir *= -1;
            }
            List<Move> ans;
            if (curBoard.board[square+(dir*8)] == 0) {
                ans.add(Move(square, square+(dir*8)));
            }
            if (curBoard.PassantFile + 1 ==  curFile || curBoard.PassantFile - 1 == curFile) {
                ans.add(Move(square, curBoard.PassantFile + (8 * (3.5+(1.5*dir)))), Move.moveType.Passant); // Possibly going to wrong side, change 3.5- to 3.5+ if so
            } else if (square / 8 == 3.5-(2.5*dir)) {
                ans.add(Move(square, square+(16*dir)), Move.moveType.PawnTwo);
            }
            if (square % 8 == 0 && curBoard.board[square+9] != 0 && !Piece.isColor(curBoard.board[square+9], Piece.getColor(curBoard.board[square]))) {
                ans.add(Move(square, square+9));
            } else if (square % 8 == 7 && curBoard.board[square+7] != 0 && !Piece.isColor(curBoard.board[square+9], Piece.getColor(curBoard.board[square]))) {
                ans.add(Move(square, square+7));
            } else {
                if (curBoard.board[square+7] != 0 && !Piece.isColor(curBoard.board[square+9], Piece.getColor(curBoard.board[square]))) {
                    ans.add(Move(square, square+7));
                }
                if (curBoard.board[square+9] != 0 && !Piece.isColor(curBoard.board[square+9], Piece.getColor(curBoard.board[square]))) {
                    ans.add(Move(square, square+9));
                }
            }
            return ans;
        }

        public List<Move> knightMoves(int square, BoardState curBoard) {
            List<Move> ans;
        }

    }
}


// 0 = 16/40
// 3 = 19/43