namespace SimpleRandom;

public partial class FormMain : Form {
    private List<int>? ints;

    public FormMain() => InitializeComponent();

    private void button1_Click(object sender, EventArgs e) {
        if (!int.TryParse(startBox.Text, out var minValue) || !int.TryParse(endBox.Text, out var maxValue)) {
            ErrMsg("���ڰ� �ƴ� ���ڿ��� �Է��߰ų� ���ڰ� �ʹ� Ů�ϴ�.");
            return;
        }

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
            ints = null;
            add(Random.Shared.Next(minValue, maxValue));
        } else {
            if (ints == null || ints.Capacity != (maxValue - minValue) || ints.Count >= (maxValue - minValue)) {
                listBox1.Items.Clear();
                ints = new(maxValue - minValue);
                add(Random.Shared.Next(minValue, maxValue));
            } else {
                int value;

                do {
                    value = Random.Shared.Next(minValue, maxValue);
                } while (ints.Contains(value));

                add(value);
            }
        }

        void add(int value) {
            numlabel.Text = value.ToString();
            listBox1.Items.Add(value);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;
            ints?.Add(value);
        }
    }

    private void button2_Click(object sender, EventArgs e) {
        numlabel.Text = null;
        listBox1.Items.Clear();
        if (ints != null) ints = null;
    }

    private void textBox_TextChanged(object sender, EventArgs e) => button1.Enabled = !string.IsNullOrWhiteSpace(startBox.Text) && !string.IsNullOrWhiteSpace(endBox.Text);
}