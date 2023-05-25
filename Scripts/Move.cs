namespace Chess {
    public class Move {

        public struct moveType {
            public const int None = 0;
            public const int Castle = 1;
            public const int Passant = 2;
            public const int PawnTwo = 3;
            public const int PromoteKnight = 4;
            public const int PromoteBishop = 5;
            public const int PromoteRook = 6;
            public const int PromoteQueen = 7;
        }

        public ushort move;

        const ushort startMask = 0b0000000000111111;
        const ushort endMask = 0b0000111111000000;
        const ushort typeMask = 0b1111000000000000;

        public Move(ushort move) {
            this.move = move;
        }
        
        public Move(ushort start, ushort end) {
            this.move = start | (end << 6);
        }

        public Move(ushort start, ushort end, ushort type) {
            this.move = start | (end << 6) | (type << 12);
        }

        public int getMove {
            get {
                return this.move;
            }
        }

        public int getStart {
            get {
                return this.move & startMask;
            }
        }

        public int getEnd {
            get {
                return this.move & endMask;
            }
        }

        public int getType {
            get {
                return this.move & typeMask;
            }
        }

    }
}