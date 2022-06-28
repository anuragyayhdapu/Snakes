#include <iostream>
#include <vector>
#include <cassert>

void draw_box();

int closest_job(const std::vector<double>& row, const std::vector<bool>& jobs_valid)
{
	double min = DBL_MAX;
	int min_index;
	for (size_t i = 0; i != row.size(); i++)
	{
		if (jobs_valid.at(i) && row.at(i) < min)
		{
			min = row.at(i);
			min_index = i;
		}
	}

	return min_index;
}

int second_closest_job(const std::vector<double>& row, const std::vector<bool>& jobs_valid)
{
	// to keep count of no. of valid jobs
	int count = 0;

	double first, second = DBL_MAX;
	int first_index, second_index;

	// set the index for smallest element
	first_index = closest_job(row, jobs_valid);
	first = row.at(first_index);

	// find the second smallest element
	for (size_t i = 0; i != row.size(); i++)
	{
		if (jobs_valid.at(i))
		{
			count++;
			if (row.at(i) < second && row.at(i) > first)
			{
				// update second & second_index
				second = row.at(i);
				second_index = i;
			}
		}
	}

	if (count > 1) return second_index;
	else return first_index;
}


int main()
{

	// there should be a game manager class and a graphics class, 
	// this is getting bigger now. 
	// Rather than going this route it would be faster to jsut use Unity


	std::vector<double> row;
	std::vector<bool> jobs_valid;

	row.push_back(12); jobs_valid.push_back(false);
	row.push_back(13); jobs_valid.push_back(false);
	row.push_back(1);  jobs_valid.push_back(false);
	row.push_back(10); jobs_valid.push_back(false);
	row.push_back(34); jobs_valid.push_back(false);
	row.push_back(-1); jobs_valid.push_back(false);


	int i = second_closest_job(row, jobs_valid);

	//assert( i == 1 );

	std::cout << i << " " << row.at(i) << "\n";

	system("PAUSE");
	return 0;
}


void draw_box()
{

}



