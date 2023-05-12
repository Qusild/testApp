﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Drawing;
using System.Net;
using Petzold.Media2D;
namespace OOPLab7
{
    public class GraphVisualizer : Canvas
    {
        public GraphVisualizer(List<List<int>> matrix, ref Canvas canvas) { 
            matrixLayout = matrix; 
            nodeSizeX = 619/(Math.Ceiling((Math.Sqrt(matrix.Count())))*2-1); 
            nodeSizeY = 334.04 /(Math.Ceiling((Math.Sqrt(matrix.Count())))*2-1);
            drawGraph(ref canvas);
        }
        public void drawGraph(ref Canvas canvas)
        {
            canvas.Children.Clear();
            int size = (int)Math.Ceiling(Math.Sqrt(matrixLayout.Count()));
            for (int i = 0; i< size;i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (matrixLayout.Count() - i * size <= j)
                        continue;
                    Rectangle tmp = new Rectangle();
                    tmp.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte((70*j)%255), Convert.ToByte((70 * i)%255), Convert.ToByte((70 * (j+i))%255)));
                    tmp.Width = nodeSizeX; tmp.Height = nodeSizeY;
                    canvas.Children.Add(tmp);
                    Canvas.SetTop(tmp, i*2 * nodeSizeY);
                    Canvas.SetLeft(tmp, j*2 * nodeSizeX);
                }
            }
            for (int i = 0; i < matrixLayout.Count();i++)
            {
                for (int j = 0; j< matrixLayout.Count();j++ )
                {
                    if (matrixLayout[i][j]==1)
                    {
                        if (i<j)
                        {
                            if (((j % size - i % size) * (j / size - i / size) <= 2) && (Math.Abs(j % size - i % size) * (j / size - i / size) >= 1) && (i % size < j % size))
                            {
                                PointCollection points = new PointCollection();
                                points.Add(new Point((i % size * 2 + 1) * nodeSizeX, (i / size * 2 + 1) * nodeSizeY));
                                points.Add(new Point(((i % size * 2 + 1) * nodeSizeX + (j % size * 2) * nodeSizeX) / 2, (((i / size * 2 + 1) * nodeSizeY) + (j / size * 2) * nodeSizeY) / 2));
                                points.Add(new Point(((i % size * 2 + 1) * nodeSizeX + (j % size * 2) * nodeSizeX) / 2, (((i / size * 2 + 1) * nodeSizeY) + (j / size * 2) * nodeSizeY) / 2));
                                points.Add(new Point((j % size * 2) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);
                            }
                            else if ((j / size == i / size))
                            {
                                PointCollection points = new PointCollection();
                                if (j - i > 1)
                                {
                                    points.Add(new Point((i % size * 2 + 1) * nodeSizeX, (i / size * 2 + 1) * nodeSizeY));
                                    points.Add(new Point((i % size * 2 + 1.5) * nodeSizeX, (i / size * 2 + 1.3) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 - 0.5) * nodeSizeX, (j / size * 2 + 1.3) * nodeSizeY));
                                    points.Add(new Point((j % size * 2) * nodeSizeX, (j / size * 2 + 1) * nodeSizeY));
                                }
                                else
                                {
                                    points.Add(new Point((i % size * 2 + 1) * nodeSizeX, (i / size * 2 + 1) * nodeSizeY));
                                    points.Add(new Point((j % size * 2) * nodeSizeX, (j / size * 2 + 1) * nodeSizeY));
                                }
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);
                            }
                            else if ((j/size != i/size)&&(j%size-i%size<2))
                            {
                                PointCollection points = new PointCollection();
                                if (j/size-i/size > 1)
                                {
                                    points.Add(new Point((i % size * 2 + 1) * nodeSizeX, (i / size * 2 + 1) * nodeSizeY));
                                    points.Add(new Point((i % size * 2 + 1.3) * nodeSizeX, (i / size * 2 + 1.5) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 + 1.3) * nodeSizeX, (j / size * 2 - 0.5) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 + 1) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                }
                                else 
                                {
                                    points.Add(new Point((i % size * 2 + 1) * nodeSizeX, (i / size * 2 + 1) * nodeSizeY));
                                    points.Add(new Point((j % size * 2+1) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                }
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);
                            }
                            else
                            {
                                PointCollection points = new PointCollection();
                                points.Add(new Point((i % size * 2 + 1) * nodeSizeX, (i / size * 2 + 1) * nodeSizeY));
                                points.Add(new Point((i % size * 2 + 1.4) * nodeSizeX, (i / size * 2 + 1.5) * nodeSizeY));
                                points.Add(new Point((i % size * 2 + 1.4) * nodeSizeX, (j / size * 2 - 0.5) * nodeSizeY));
                                points.Add(new Point((j % size * 2 - 0.4) * nodeSizeX, (j / size * 2 - 0.5) * nodeSizeY));
                                points.Add(new Point((j % size * 2) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);
                            }
                        }
                        else if (i==j)
                        {
                            Ellipse ellipse = new Ellipse();
                            ellipse.Stroke = SystemColors.WindowFrameBrush;
                            ellipse.Width = 40;
                            ellipse.Height = 40;
                            canvas.Children.Add(ellipse);
                            Canvas.SetTop(ellipse, (i / size * 2 + 1) * nodeSizeY-8);
                            Canvas.SetLeft(ellipse, (i % size * 2 + 1) * nodeSizeX-8);
                        }
                        else
                        {
                            if ((i/size -j/size >1)&&(i%size-j%size >0))
                            {
                                PointCollection points = new PointCollection();
                                points.Add(new Point((i % size * 2) * nodeSizeX, (i / size * 2) * nodeSizeY));
                                points.Add(new Point((i % size * 2 - 0.2) * nodeSizeX, (i / size * 2 - 0.2) * nodeSizeY));
                                if (i % size - j % size > 1)
                                {
                                    points.Add(new Point((i % size * 2 -0.2) * nodeSizeX, (j / size * 2 + 1.8) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 + 1.8) * nodeSizeX, (j / size * 2 + 1.8) * nodeSizeY));
                                }
                                points.Add(new Point((j % size * 2 + 1.8) * nodeSizeX, (j / size * 2 + 0.8) * nodeSizeY));
                                points.Add(new Point((j % size * 2 + 1) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);

                            }
                            else if ((j / size == i / size))
                            {
                                PointCollection points = new PointCollection();
                                if (i - j > 1)
                                {
                                    points.Add(new Point((i % size * 2) * nodeSizeX, (i / size * 2) * nodeSizeY));
                                    points.Add(new Point((i % size * 2 - 0.3) * nodeSizeX, (i / size * 2 - 0.3) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 + 1.3) * nodeSizeX, (j / size * 2 - 0.3) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 + 1) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                }
                                else
                                {
                                    points.Add(new Point((i % size * 2) * nodeSizeX, (i / size * 2) * nodeSizeY));
                                    points.Add(new Point((j % size * 2+1) * nodeSizeX, (j / size * 2) * nodeSizeY));
                                }
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);
                            }
                            else if ((j / size != i / size) && (j % size - i % size < 2))
                            {
                                PointCollection points = new PointCollection();
                                if (i / size - j / size > 1)
                                {
                                    points.Add(new Point((i % size * 2) * nodeSizeX, (i / size * 2) * nodeSizeY));
                                    points.Add(new Point((i % size * 2 - 0.6) * nodeSizeX, (i / size * 2 - 0.5) * nodeSizeY));
                                    points.Add(new Point((j % size * 2 - 0.6) * nodeSizeX, (j / size * 2 + 1.5) * nodeSizeY));
                                    points.Add(new Point((j % size * 2) * nodeSizeX, (j / size * 2+1) * nodeSizeY));
                                }
                                else
                                {
                                    points.Add(new Point((i % size * 2) * nodeSizeX, (i / size * 2) * nodeSizeY));
                                    points.Add(new Point((j % size * 2) * nodeSizeX, (j / size * 2+1) * nodeSizeY));
                                }
                                ArrowPolyline arrow = new ArrowPolyline();
                                arrow.Stroke = System.Windows.Media.Brushes.SlateGray;
                                arrow.Points = points;
                                canvas.Children.Add(arrow);
                            }
                        }
                    }
                }
            }
        }

        private List<List<int>> matrixLayout;
        private readonly double nodeSizeX;
        private readonly double nodeSizeY;
    }
}
