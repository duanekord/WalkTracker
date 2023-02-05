namespace WalkTracker;

public partial class MainPage : ContentPage
{
	int count = 0;
	private const string countKey = "mileCount";
	int dayOfYear = DateTime.Today.DayOfYear;


	public MainPage()
	{
		InitializeComponent();
		getCountFromSettings();
		determineDateDiff();
		setDateProgressValue();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		determineDateDiff();
		setDateProgressValue();
		setCount();
	}

	private void determineDateDiff()
	{
		if (dayOfYear == count)
		{
			DayDiffLabel.Text = "You are all caught up!";
		}
		else if (dayOfYear < count)
		{
			DayDiffLabel.Text = $"You are {(dayOfYear - count) * -1} days ahead!  Great Job!";
		}
		else
		{
			DayDiffLabel.Text = $"You are {(count - dayOfYear) * -1} days behind.  You got this!";
		}
	}

	private void setDateProgressValue()
	{
		var newProgressValue = 1.0 - ((dayOfYear - count) / 100.0);

		WalkProgress.ProgressTo(newProgressValue, 100, Easing.Linear);
	}

	private void getCountFromSettings()
	{
			count = Preferences.Default.Get(countKey, 0);
	}

	private void setCount()
	{
		Preferences.Default.Set(countKey, count);
	}
}

