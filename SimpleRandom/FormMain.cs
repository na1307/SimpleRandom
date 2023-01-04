namespace SimpleRandom;

public partial class FormMain {
    private List<int>? noDupNumbers;

    public FormMain() => InitializeComponent();

    private async void button1_Click(object sender, EventArgs e) {
        if (!int.TryParse(startBox.Text, out var minValue) || !int.TryParse(endBox.Text, out var maxValue)) {
            ErrMsg("숫자가 아닌 문자열을 입력했거나 숫자가 너무 큽니다.");
            return;
        }

        if (minValue < 0) {
            ErrMsg("최소값은 음수일 수 없습니다.");
            return;
        }

        if (minValue > maxValue) {
            ErrMsg("최소값은 최대값보다 클 수 없습니다.");
            return;
        }

        maxValue++;

        if (!checkBox1.Checked) {
            if (noDupNumbers != null) {
                noDupNumbers = null;
                listBox1.Items.Clear();
                progressBar1.Maximum = 0;
                progressBar1.Value = 0;
            }

            addNumber(Random.Shared.Next(minValue, maxValue));
        } else if (noDupNumbers == null || noDupNumbers.Capacity != (maxValue - minValue)) {
            init();
        } else if (noDupNumbers.Count >= (maxValue - minValue)) {
            if (MessageBox.Show("모든 숫자를 뽑았습니다." + Environment.NewLine + Environment.NewLine + "처음부터 다시 시작할까요?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes) init();
        } else {
            button1.Enabled = false;
            numlabel.Text = "뽑는 중...";
            addNumber(await Task.Factory.StartNew(() => {
                int value;

                do {
                    value = Random.Shared.Next(minValue, maxValue);
                } while (noDupNumbers.Contains(value));

                return value;
            }, TaskCreationOptions.LongRunning));
            button1.Enabled = true;
            button1.Focus();
        }

        void addNumber(int value) {
            numlabel.Text = value.ToString();
            listBox1.Items.Add(value);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;

            if (noDupNumbers != null) {
                noDupNumbers.Add(value);
                progressBar1.Value++;
            }
        }

        void init() {
            listBox1.Items.Clear();
            noDupNumbers = new(maxValue - minValue);
            progressBar1.Maximum = noDupNumbers.Capacity;
            progressBar1.Value = 0;
            addNumber(Random.Shared.Next(minValue, maxValue));
        }
    }

    private void button2_Click(object sender, EventArgs e) {
        numlabel.Text = null;
        listBox1.Items.Clear();
        progressBar1.Maximum = 0;
        progressBar1.Value = 0;
        if (noDupNumbers != null) noDupNumbers = null;
    }

    private void textBox_TextChanged(object sender, EventArgs e) => button1.Enabled = !string.IsNullOrWhiteSpace(startBox.Text) && !string.IsNullOrWhiteSpace(endBox.Text);
}