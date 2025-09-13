namespace GettingStarted.StepDefinitions
{
    [Binding]
    public class GettingStartedTestsStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public GettingStartedTestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When("I get value (.*)")]
        public void WhenIGetValue(string value)
        {
            _scenarioContext.Set(value, "value");
        }

        [Then("value should be null")]
        public void ThenValueShouldBeNull()
        {
            Assert.Null(_scenarioContext.Get<string>("value"));
        }
    }
}
