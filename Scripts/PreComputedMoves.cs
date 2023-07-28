using System.Collections.Generic;

namespace Chess {
    public class PreComputedMoves { // Probably should precompute pawns since every optimization is important
        
        public static int[] offsets = {8, 9, 1, -7, -8, -9, -1, 7};
        public static int[] edges = {0,1,2,3,4,5,6,7,8,16,24,32,40,48,56,57,58,59,60,61,62,63,55,47,39,31,23,15,-1,-2,-3,-4,-5,-6,-7,-8,64,65,66,67,68,69,70,71};

        public Dictionary<int, List<int>> rookMoves = new Dictionary<int, List<int>>(); // Maybe use List<List<int>> instead of -1 to mark different directions
        public Dictionary<int, List<int>> bishopMoves = new Dictionary<int, List<int>>();
        public Dictionary<int, List<int>> kingMoves = new Dictionary<int, List<int>>(); // Might have -1 sprinkled in, but these can be ignored or maybe removed
        public Dictionary<int, List<int>> knightMoves = new Dictionary<int, List<int>>();

        public PreComputedMoves() {
            GenerateRook();
            GenerateBishop();
            GenerateKing();
            GenerateKnight();
        }

        private void GenerateRook() {
            for (int file = 0; file < 8; file++) {
                for (int rank = 0; rank < 8; rank++) {
                    List<int> add = new List<int>();
                    int start = (rank * 8) + file;
                    for (int cur = start+8; cur <= 56+file; cur+=8) {
                        add.Add(cur);
                    }
                    add.Add(-1);
                    for (int cur = start-8; cur >= file; cur-=8) {
                        add.Add(cur);
                    }
                    add.Add(-1);
                    for (int cur = start+1; cur <= (rank*8)+7; cur+=1) {
                        add.Add(cur);
                    }
                    add.Add(-1);
                    for (int cur = start-1; cur >= rank*8; cur-=1) {
                        add.Add(cur);
                    }
                    add.Add(-1);
                    rookMoves.Add(start, add);
                }
            }
        }

        private void GenerateBishop() {
            for (int file = 0; file < 8; file++) {
                for (int rank = 0; rank < 8; rank++) {
                    List<int> add = new List<int>();
                    int start = (rank * 8) + file;
                    for (int cur = start+7; cur <= Math.Min(8*(rank+file), 57+(8 % (rank+file))); cur+=7) { // 57 could be off
                        add.Add(cur);
                    }
                    add.Add(-1);
                    for (int cur = start+9; cur <= Math.Min(7+(8*(7-file+rank)), 62-(8 % (7-file+rank))); cur+=9) { // using mod rather than recentering 0 is likely to cause problems
                        add.Add(cur);
                    }
                    add.Add(-1);
                    for (int cur = start-7; cur >= Math.Max(rank+file+1, 7+(8*(-7+rank+file))); cur-=7) {
                        add.Add(cur);
                    }
                    add.Add(-1);
                    for (int cur = start-9; cur >= Math.Max(file-rank, 8 * (rank-file)); cur-=9) { 
                        add.Add(cur);
                    }
                    add.Add(-1);
                    bishopMoves.Add(start, add);
                }
            }
        }

        private void GenerateKing() { // Take first move from each direction of bishop and rook
            for (int file = 0; file < 8; file++) {
                for (int rank = 0; rank < 8; rank++) {
                    List<int> add = new List<int>();
                    int start = (rank * 8) + file;
                    
                }
            }
        }

    }
}