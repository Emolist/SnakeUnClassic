using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FigurineObstacles : MonoBehaviour
{
    public int number, figure;
    private string number_string;
    public Collector collector;
    public Image targetImage;
    public GameObject neededNumber;
    public Canvas canvas;


    private void Awake()
    {
        collector = GameObject.FindWithTag("Collector").GetComponent<Collector>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    void Start()
    {
        figure = Random.Range(0, 5);
        if (collector.Count[figure] > 3)
        {
            number = Random.Range(collector.Count[figure] - 2, collector.Count[figure] + 2 + Score.totalScore);
        } else number = Random.Range(1, collector.Count[figure] + 2 + Score.totalScore);

        number_string = number.ToString();

        FigurineObstacleLayout img = Instantiate(targetImage,new Vector3(0,7f,0),Quaternion.identity, canvas.transform).GetComponent<FigurineObstacleLayout>();
        img.obstacle = this.gameObject;
        img.ChangeSprite(collector.GetComponent<SpriteHolder>().FigureReturn(figure));
        GameObject num = Instantiate(neededNumber, canvas.transform);
        num.GetComponent<FigurineObstacleLayout>().obstacle = this.gameObject;
        num.GetComponent<TMP_Text>().text = number_string;
    }

    public void Pass()
    {
        Destroy(this.gameObject);
    }
}
