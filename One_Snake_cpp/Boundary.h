#pragma once
#ifndef _BOUNDARY_
#define _BOUNDARY_

#include <iostream>


// for boundary management
class Boundary
{

	double min_x, max_x, min_y, max_y;

public:

	// Draw the boundary
	void draw();

	// to check if snake is inside boundary or not
	bool is_inside(double, double);

	Boundary(double, double, double, double);
};


#endif // !_BOUNDARY_
