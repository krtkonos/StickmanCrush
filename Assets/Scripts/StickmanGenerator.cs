using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanGenerator : MonoBehaviour
{
    [Header("Borders")] //stickman spawner
    [SerializeField] private GameObject leftTopBorder;
    [SerializeField] private GameObject leftBottomBorder;
    [SerializeField] private GameObject rightTopBorder;
    [SerializeField] private GameObject rightBottomBorder;
    [Header("Stickmans")]
    [SerializeField] private GameObject stickmanPrefab;

    private float _StartGameTime = 0f;
    private float _CurrentTime = 1.5f;
    
    void Update()
    {
        _StartGameTime += Time.deltaTime;
        _CurrentTime -= Time.deltaTime;

        if (_CurrentTime < 0f)
        {
            GenerateStickman();
            _CurrentTime = 1.6f - Mathf.Clamp(_StartGameTime / 20f, 0.1f, 1.3f);
        }

        Stickman.run = 5f + 5f * Mathf.Clamp(_StartGameTime / 100f, 0f, 1.5f);
    }

    private void GenerateStickman()
    {
        bool leftside = (Random.Range(0f, 1f) > 0.5f);

        Vector2 spawnPosition = new Vector2(); //stickman spawn generator
        if (leftside)
        {
            spawnPosition.x = leftTopBorder.transform.position.x;
            spawnPosition.y = Random.Range(leftBottomBorder.transform.position.y, leftTopBorder.transform.position.y);
        }
        else
        {
            spawnPosition.x = rightTopBorder.transform.position.x;
            spawnPosition.y = Random.Range(rightBottomBorder.transform.position.y, rightTopBorder.transform.position.y);
        }

        GameObject stickman = Instantiate(stickmanPrefab, spawnPosition, new Quaternion(), transform);
        if (!leftside)
        {
            stickman.transform.Rotate(0.0f, 180.0f, 0.0f); // turn the run direction
        }
    }
}
