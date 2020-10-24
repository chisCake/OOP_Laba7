using System;
using System.IO;

namespace OOP_Laba7 {
	class CustomIndexOutOfRangeException : ArgumentOutOfRangeException {
		public readonly int minValue;
		public readonly int maxValue;

		public CustomIndexOutOfRangeException(int maxValue, int minValue = 0, string msg = null) : base(msg) {
			this.minValue = minValue;
			this.maxValue = maxValue;
		}

		public CustomIndexOutOfRangeException(string param, int actualValue, int maxValue, int minValue = 0, string msg = null) : base(param, actualValue, msg) {
			this.minValue = minValue;
			this.maxValue = maxValue;
		}
	}

	class InputDataException : Exception {
		public readonly string availableType;

		public InputDataException(string availableType, string msg = null) : base(msg) {
			this.availableType = availableType;
		}
	}

	class FilePathException : FileNotFoundException {
		public readonly string path;

		public FilePathException(string path, string msg) : base(msg) {
			this.path = path;
		}
	}
}
