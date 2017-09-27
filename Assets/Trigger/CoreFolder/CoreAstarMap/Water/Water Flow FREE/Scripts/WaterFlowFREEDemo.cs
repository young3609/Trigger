using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WaterFlowFREEDemo : MonoBehaviour
{

	// Water Simple
	Color m_WaterSimple_Color;
	float m_WaterSimple_UMoveSpeed;
	float m_WaterSimple_VMoveSpeed;
	Color m_WaterSimpleOriginal_Color;
	float m_WaterSimpleOriginal_UMoveSpeed;
	float m_WaterSimpleOriginal_VMoveSpeed;

	// Water game objects
	public GameObject m_SimpleWater;

	void Start()
	{

		// Get information from Simple water's material.
		m_WaterSimpleOriginal_Color = m_SimpleWater.GetComponent<Renderer>().material.GetColor("_Color");
		m_WaterSimpleOriginal_UMoveSpeed = m_SimpleWater.GetComponent<Renderer>().material.GetFloat("_MoveSpeedU");
		m_WaterSimpleOriginal_VMoveSpeed = m_SimpleWater.GetComponent<Renderer>().material.GetFloat("_MoveSpeedV");
		m_WaterSimple_Color = m_WaterSimpleOriginal_Color;
		m_WaterSimple_UMoveSpeed = m_WaterSimpleOriginal_UMoveSpeed;
		m_WaterSimple_VMoveSpeed = m_WaterSimpleOriginal_VMoveSpeed;
	}

	void Update()
	{
	}

	// Red color
	void OnSlider_SimpleR(float value)
	{
		m_WaterSimple_Color = new Color(value,
									m_WaterSimple_Color.g,
									m_WaterSimple_Color.b,
									m_WaterSimple_Color.a);
		m_SimpleWater.GetComponent<Renderer>().material.SetColor("_Color", m_WaterSimple_Color);
	}

	// Green color
	void OnSlider_SimpleG(float value)
	{
		m_WaterSimple_Color = new Color(m_WaterSimple_Color.r,
									value,
									m_WaterSimple_Color.b,
									m_WaterSimple_Color.a);
		m_SimpleWater.GetComponent<Renderer>().material.SetColor("_Color", m_WaterSimple_Color);
	}

	// Blue color
	void OnSlider_SimpleB(float value)
	{
		m_WaterSimple_Color = new Color(m_WaterSimple_Color.r,
									m_WaterSimple_Color.g,
									value,
									m_WaterSimple_Color.a);
		m_SimpleWater.GetComponent<Renderer>().material.SetColor("_Color", m_WaterSimple_Color);
	}

	// U speed
	void OnSlider_SimpleUSpeed(float value)
	{
		m_WaterSimple_UMoveSpeed = value;
		m_SimpleWater.GetComponent<Renderer>().material.SetFloat("_MoveSpeedU", m_WaterSimple_UMoveSpeed);
	}

	// V speed
	void OnSlider_SimpleVSpeed(float value)
	{
		m_WaterSimple_VMoveSpeed = value;
		m_SimpleWater.GetComponent<Renderer>().material.SetFloat("_MoveSpeedV", m_WaterSimple_VMoveSpeed);
	}

}
