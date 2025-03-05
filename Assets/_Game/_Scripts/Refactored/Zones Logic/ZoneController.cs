using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ZoneController
{
    private Dictionary<ZoneType, List<Zone>> _zones = new();

    public ZoneController(List<Zone> allZones)
    {
        foreach (var zone in allZones)
        {
            if (!_zones.ContainsKey(zone.Type))
            {
                _zones[zone.Type] = new List<Zone>();
            }
            _zones[zone.Type].Add(zone);
        }
    }

    public bool ContainsCollider(ZoneType type, Collider2D collider)
    {
        if (!_zones.ContainsKey(type)) return false;
        return _zones[type].Any(zone => zone.ContainsCollider(collider));
    }

    public bool ContainsPoint(ZoneType type, Vector2 point)
    {
        if (!_zones.ContainsKey(type)) return false;
        return _zones[type].Any(zone => zone.ContainsPoint(point));
    }

    public bool ContainsRectTransform(ZoneType type, RectTransform rectTransform)
    {
        if (!_zones.ContainsKey(type)) return false;
        
        return _zones[type].Any(zone => zone.ContainsRectTransform(rectTransform));
    }

    public void SetZonesActive(ZoneType type, bool isActive)
    {
        if (!_zones.ContainsKey(type)) return;
        foreach (var zone in _zones[type])
        {
            zone.gameObject.SetActive(isActive);
        }
    }

    public void SetAllZonesActive(bool isActive)
    {
        foreach (var zoneList in _zones.Values)
        {
            foreach (var zone in zoneList)
            {
                zone.gameObject.SetActive(isActive);
            }
        }
    }
}