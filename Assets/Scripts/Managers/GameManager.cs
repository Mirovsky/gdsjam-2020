using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private FadeInOutManager _fadeInOutManager = default;
    [Inject] private EndGameDataModel _endGameDataModel = default;
    [Inject] private TruthDataModel _truthDataModel = default;
    [Inject] private ScenesManager _scenesManager = default;
    
    public event Action levelLoadedEvent;
    public event Action levelStartEvent;
    public event Action levelFinishedEvent;
    
    private List<TruthAgent> _truthAgents;

    public IReadOnlyList<TruthAgent> truthAgents => _truthAgents;
    
    protected void Awake()
    {
        _truthAgents = new List<TruthAgent>();
    }
    
    protected void Start()
    {
        _endGameDataModel.Clear();
        
        levelLoadedEvent?.Invoke();
        
        _fadeInOutManager.FadeIn(() =>
        {
            levelStartEvent?.Invoke();
        });
    }

    public void RegisterTruthAgent(TruthAgent truthAgent)
    {
        _truthAgents.Add(truthAgent);
    }

    public float CalculateFinishScore()
    {
        var maxScore = _truthAgents.Count * _truthDataModel.GetMaxTruth();
        var score = _truthAgents.Sum(agent => agent.truthAmount);

        return score / maxScore;
    }
    
    public void FinishGame()
    {
        _endGameDataModel.SetScore(CalculateFinishScore());
        
        _scenesManager.ToEndGame();
    }
}
