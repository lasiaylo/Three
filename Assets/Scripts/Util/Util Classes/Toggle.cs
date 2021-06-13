namespace Util {
    public class Toggle {
        public Toggle(bool status = false) {
            Status = status;
        }

        public bool Status { get; private set; }

        public static implicit operator bool(Toggle toggle) {
            return toggle.Status;
        }

        public static implicit operator int(Toggle toggle) {
            return toggle.Status ? 1 : 0;
        }

        public bool Flip() {
            Status = !Status;
            return Status;
        }
    }
}