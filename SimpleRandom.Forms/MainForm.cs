namespace SimpleRandom.Forms;

public partial class MainForm {
    private NoDupNumberProvider? provider;

    public MainForm() => InitializeComponent();

    private async void button1_Click(object sender, EventArgs e) {
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
            if (provider != null) {
                provider = null;
                listBox1.Items.Clear();
                progressBar1.Maximum = 0;
                progressBar1.Value = 0;
            }

            addNumber(Random.Shared.Next(minValue, maxValue));
        } else if (provider == null || provider.Capacity != (maxValue - minValue)) {
            await noDupInit();
        } else {
            button1.Enabled = false;
            numlabel.Text = "�̴� ��...";

            try {
                addNumber(await provider.GetNumber());
            } catch (NothingToGetException) {
                numlabel.Text = string.Empty;

                if (MessageBox.Show("��� ���ڸ� �̾ҽ��ϴ�." + Environment.NewLine + Environment.NewLine + "ó������ �ٽ� �����ұ��?", "�˸�", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    await noDupInit();
                }
            }

            button1.Enabled = true;
            button1.Focus();
        }

        void addNumber(int value) {
            numlabel.Text = value.ToString();
            listBox1.Items.Add(value);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.SelectedIndex = -1;

            if (provider != null) {
                progressBar1.Value++;
            }
        }

        async Task noDupInit() {
            listBox1.Items.Clear();
            provider = new(minValue, maxValue);
            progressBar1.Maximum = provider.Capacity;
            progressBar1.Value = 0;
            addNumber(await provider.GetNumber());
        }
    }

    private void button2_Click(object sender, EventArgs e) {
        numlabel.Text = null;
        listBox1.Items.Clear();
        progressBar1.Maximum = 0;
        progressBar1.Value = 0;
        provider = null;
    }

    private void textBox_TextChanged(object sender, EventArgs e) =>
        // �ּҰ��� �ִ밪�� ��� ������� ���� ����
        button1.Enabled = !string.IsNullOrWhiteSpace(startBox.Text) && !string.IsNullOrWhiteSpace(endBox.Text);
}
