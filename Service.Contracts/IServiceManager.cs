namespace Service.Contracts
{
	public interface IServiceManager
	{
		IUserService UserService { get; }
		IWeatherApiService WeatherApiService { get; }
		IAuthService AuthService { get; }
		IPreferencesService PreferencesService { get; }
	}
}
