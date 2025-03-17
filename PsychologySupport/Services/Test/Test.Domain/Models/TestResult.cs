﻿using BuildingBlocks.DDD;
using Test.Domain.Enums;
using Test.Domain.ValueObjects;

namespace Test.Domain.Models;

public class TestResult : AggregateRoot<Guid>
{
    private TestResult()
    {
        SelectedOptions = new List<QuestionOption>();
    }


    public TestResult(Guid id, Guid patientId, Guid testId, Score depressionScore,
        Score anxietyScore, Score stressScore, SeverityLevel severityLevel, string recommendation)
    {
        Id = id;
        PatientId = patientId;
        TestId = testId;
        TakenAt = DateTime.UtcNow;
        DepressionScore = depressionScore;
        AnxietyScore = anxietyScore;
        StressScore = stressScore;
        SeverityLevel = severityLevel;
        Recommendation = recommendation;
    }

    public Guid PatientId { get; private set; }
    public Guid TestId { get; private set; }
    public DateTime TakenAt { get; private set; }
    public Score DepressionScore { get; private set; }
    public Score AnxietyScore { get; private set; }
    public Score StressScore { get; private set; }
    public SeverityLevel SeverityLevel { get; private set; }
    public string Recommendation { get; private set; }
    public virtual ICollection<QuestionOption> SelectedOptions { get; private set; }


    public static TestResult Create(Guid patientId, Guid testId, Score depressionScore,
        Score anxietyScore, Score stressScore, SeverityLevel severityLevel,
        string recommendation, List<QuestionOption>? selectedOptions)
    {
        var newTestResult = new TestResult(Guid.NewGuid(), patientId, testId, depressionScore, anxietyScore, stressScore,
            severityLevel, recommendation);

        foreach (var option in selectedOptions)
        {
            newTestResult.SelectedOptions.Add(option);
        }
        return newTestResult;
    }

    public void AddSelectedOptions(IEnumerable<QuestionOption> options)
    {
        foreach (var option in options)
        {
            SelectedOptions.Add(option);
        }
    }
}