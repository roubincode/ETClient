namespace ETModel
{
    
	public class SessionWrapComponent: Component
	{
		public static SessionWrapComponent Instance;

		public SessionWrap Session;

		public void Awake()
		{
			Instance = this;
		}

		public override void Dispose()
		{
			if (this.IsDisposed)
			{
				return;
			}

			base.Dispose();

			this.Session.Dispose();
			this.Session = null;
			Instance = null;
		}
	}
}
