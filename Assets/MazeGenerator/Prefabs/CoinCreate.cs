using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreate : MonoBehaviour
{
    public GameObject Coin;
    float[] randlistX;
    float[] randlistZ;
    // Start is called before the first frame update
    void Start()
    {
        randlistX = GetRandom(40, -50, 50);
        randlistZ = GetRandom(40, -50, 50);

        for (int i = 0; i < 30; i++)
        {
            GameObject coin = GameObject.Instantiate(Coin);
            coin.transform.position = new Vector3(randlistX[i], 1, randlistZ[i]);
            coin.transform.rotation = Quaternion.Euler(0, 0, 0);
            coin.transform.parent = null;
            //Debug.Log(randlistX[i]+ " , " + randlistZ[i]);
        }
    }

    public float[] GetRandom(int length, int min, int max)
    {
        float[] randArray = new float[length];
        bool same;

        for (int i = 0; i < length; i++)
        {
            while (true)
            {
                randArray[i] = Random.Range(min + 0.5f, max - 0.5f);
                same = false;

                for (int j = 0; j < i; j++)
                {
                    if (randArray[j] == randArray[i])// �������� ������ �ߺ� �ִ��� Ȯ��
                    {
                        same = true;
                        break;
                    }
                }
                if (!same) break;   // �ߺ������� �ٽ� ����, �ߺ� ������ ���� �� ���� (for ������ ��)
            }

        }
        return randArray;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
