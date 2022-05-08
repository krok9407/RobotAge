using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public static class Bezier
{
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return oneMinusT * oneMinusT * p0 + 2f * oneMinusT * t * p1 + t * t * p2;
    }
 
    //time from 0 to 1
    public static Vector3 GetPoint(IList<Vector3> points, float tolerance, float time)
    {
        if (time >= 1f) return points[points.Count - 1];
        if (time <= 0f) return points[0];
 
        var uniformTime = (points.Count) * 2 * time;
        var i = (int)uniformTime;
        var t = uniformTime - i;
        if (i % 2 == 1)
        {
            //stright segment
            i /= 2;
            if (i >= points.Count - 1)
                return points[points.Count - 1];
            var p0 = points[i];
            var p1 = points[i + 1];
            var dir = GetDir(p0, p1, tolerance);
            p0 = p0 + dir;
            p1 = p1 - dir;
            var res = Vector3.Lerp(p0, p1, t);
            return res;
        }
        else
        {
            //curved segment
            i /= 2;
            var p0 = i == 0 ? points[0] : points[i - 1];
            var p1 = points[i];
            var p2 = i == points.Count - 1 ? points[points.Count - 1] : points[i + 1];
            var dir0 = GetDir(p1, p0, tolerance);
            var dir1 = GetDir(p1, p2, tolerance);
            p0 = p1 + dir0;
            p2 = p1 + dir1;
            var res = GetPoint(p0, p1, p2, t);
            return res;
        }
    }
 
    private static Vector3 GetDir(Vector3 p0, Vector3 p1, float tolerance)
    {
        var diff = (p1 - p0);
        var diffLen = diff.magnitude;
        if (diffLen < tolerance * 2)
            return diff / 2;
        if (diffLen <= float.Epsilon)
            return Vector3.zero;
        var dir = tolerance * diff / diffLen;
        return dir;
    }
 
    public static IEnumerator MoveAlong(Transform transform, Vector3[] points, float tolerance, float runSpeed, float step = 0.001f)
    {
        if (points.Length == 0)
            yield break;
 
        for (float time = 0; time <= 1; time += step)
        {
            var point = GetPoint(points, tolerance, time);
 
            RotateImmediatelyTo(transform, point);
 
            while (Vector3.SqrMagnitude(transform.position - point) > 0.01f)
            {
                yield return null;
                transform.position = Vector3.MoveTowards(transform.position, point, runSpeed * Time.deltaTime);
            }
        }
 
        transform.position = points[points.Length - 1];
    }
 
    static void RotateImmediatelyTo(Transform transform, Vector3 point)
    {
        if (Vector3.SqrMagnitude(transform.position - point) > 0.01f)
        {
            var curLook = transform.forward;
            var to = (point - transform.position).normalized;
            transform.forward = to;
        }
    }
}