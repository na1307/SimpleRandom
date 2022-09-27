namespace RandomForms;

public partial class FormMain : Form {
    private List<int>? ints;

    public FormMain() => InitializeComponent();

    private void button1_Click(object sender, EventArgs e) {
        if (string.IsNullOrWhiteSpace(startBox.Text) || string.IsNullOrWhiteSpace(endBox.Text)) return;

        try {
            var minValue = int.Parse(startBox.Text);
            var maxValue = int.Parse(endBox.Text);

            if (minValue < 0) {
                ErrMsg("�ּҰ��� ������ �� �����ϴ�.");
                return;
            }

            if (minValue > maxValue) {
                ErrMsg("�ּҰ��� �ִ밪���� Ŭ �� �����ϴ�.");
                return;
            }

            maxValue++;

            if (!checkBox1.Checked) {
                if (ints != null) ints = null;

                add(getRandom(minValue, maxValue));
            } else {
                if (ints == null || (ints.Capacity == (maxValue - minValue) && ints.Count >= (maxValue - minValue)) || ints.Capacity != (maxValue - minValue)) {
                    listBox1.Items.Clear();
                    ints = new(maxValue - minValue);
                    add(getRandom(minValue, maxValue));
                } else {
                    int value;

                    do {
                        value = getRandom(minValue, maxValue);
                    } while (ints.Contains(value));

                    add(value);
                }
            }
        } catch (FormatException) {
            ErrMsg("���ڸ� �Է��ϼ���.");
        } catch (OverflowException) {
            ErrMsg("���ڰ� �ʹ� Ů�ϴ�.");
        }

        static int getRandom(int minValue, int maxValue) => Random.Shared.Next(minValue, maxValue);

        void add(int value) {
            numlabel.Text = value.ToString();
            listBox1.Items.Add(value);

            if (ints != null) ints.Add(value);
        }
    }

    private void button2_Click(object sender, EventArgs e) {
        numlabel.Text = null;
        listBox1.Items.Clear();

        if (ints != null) ints = null;
    }
}