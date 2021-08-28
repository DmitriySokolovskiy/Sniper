using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TargetCreator : MonoBehaviour
{
    /// <summary>
    /// Элементы из которых создается мишень.
    /// </summary>
    [SerializeField] private GameObject[] targetElements = new GameObject[4];      
    [SerializeField] private int countColumns = 7;
    [SerializeField] private int countRows = 7;
    /// <summary>
    /// Элементы созданной мишени.
    /// </summary>
    [SerializeField] private List<GameObject> currentTargetObjects;
    private float centerRow;
    private float centerColumn;
    private int objNumber;
    private float sizeGameObject;

    private void Awake() 
    {
        sizeGameObject = targetElements[0].GetComponent<BoxCollider>().size.x;
        centerRow = Mathf.Round(countRows * 0.5f);
        centerColumn = Mathf.Round(countColumns * 0.5f);
    }
    
    public void CreateTarget(Vector3 targetPosition) 
    {
        Vector3 firstPos = new Vector3(targetPosition.x - sizeGameObject * countColumns, targetPosition.y, targetPosition.z);
        
        for (int row = 1 ; row <= countRows; row++)
        {
            targetPosition += new Vector3(0, sizeGameObject, 0);

            for (int column = 1; column <= countColumns; column++)
            {
                SelectTargetObject(row, column);
                Vector3 currentElementPos = new Vector3 (firstPos.x + column * sizeGameObject, targetPosition.y, targetPosition.z);
                GameObject instantiatedGameObject = objNumber >= targetElements.Length ? targetElements.Last() : targetElements[objNumber];
                GameObject currentGameObject = Instantiate(instantiatedGameObject, currentElementPos, Quaternion.identity);
                currentTargetObjects.Add(currentGameObject);
            }
        }
    }

    /// <summary>
    /// Производит выбор элемента для текущего слоя мишени.
    /// </summary>
    private void SelectTargetObject(float row, float column)
    {
        for (objNumber = 0; objNumber <= centerRow; objNumber++) 
        {
            if (row <= centerRow + objNumber && column <= centerColumn + objNumber && row >= centerRow - objNumber && column >= centerColumn - objNumber) 
            {
                break;
            }
        }
    }

    public void DestroyTarget() 
    {
        foreach (GameObject currentGameObject in currentTargetObjects) 
        {
            Destroy(currentGameObject);
        }
    }
}