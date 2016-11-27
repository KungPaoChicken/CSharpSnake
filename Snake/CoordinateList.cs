using System;

namespace Snake {
    public class CoordinateList {
        protected Coordinate[] coordinates;
        public int length { get; private set; }

        public CoordinateList(int maxLength) {
            coordinates = new Coordinate[maxLength];
        }

        public void add(Coordinate c) {
            coordinates[length] = c;
            length++;
        }

        public Coordinate get(int index) {
            return coordinates[index];
        }

        public void set(int index, Coordinate c) {
            if (index < length) {
                coordinates[index] = c;
            }
        }

        public void shift(int sourceIndex, int destIndex, int length) {
            Array.Copy(coordinates, sourceIndex, coordinates, destIndex, length);
        }

        public bool contains(Coordinate coordinate) {
            for (int i = 0; i < length; i++) {
                if (coordinates[i].Equals(coordinate)) {
                    return true;
                }
            }
            return false;
        }
    }
}
