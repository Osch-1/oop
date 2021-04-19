#include <iostream>
#include <iomanip>
#include <fstream>
#include <optional>
#include <string>
#include <vector>
#include <sstream>

using namespace std;

const int REQUIRED_VALUES_NUMBER = 2;
const int ALLOWED_MATRIX_DEGREE = 3;

struct Arguments
{
	string inputFileName;
};

struct Matrix3x3
{
	double values[ALLOWED_MATRIX_DEGREE][ALLOWED_MATRIX_DEGREE];
};

Arguments FormArguments(const string& inputFileName)
{
	Arguments arguments;

	arguments.inputFileName = inputFileName;

	return arguments;
}

optional<Arguments> ParseInputArgs(int argc, char* argv[])
{
	if (argc != REQUIRED_VALUES_NUMBER)
	{
		return nullopt;
	}

	return FormArguments(argv[1]);
}

optional<Matrix3x3> ReadMatrixFromStream(istream& inputStream)
{
	Matrix3x3 matrix;

	for (int i = 0; i < ALLOWED_MATRIX_DEGREE; ++i)
	{
		string buffer;

		getline(inputStream, buffer);
		stringstream strStream;
		strStream << buffer;

		for (int j = 0; j < ALLOWED_MATRIX_DEGREE; ++j)
		{
			if (!(strStream >> matrix.values[i][j]))
			{
				return nullopt;
			}
		}
	}

	return matrix;
};

void PrintMatrix(const Matrix3x3& matrix)
{
	for (int i = 0; i < ALLOWED_MATRIX_DEGREE; ++i)
	{
		for (int j = 0; j < ALLOWED_MATRIX_DEGREE; ++j)
		{
			cout << matrix.values[i][j];

			if (j != ALLOWED_MATRIX_DEGREE - 1)
			{
				cout << " ";
			}
		}

		cout << endl;
	}
};

double GetMatrixDeterminant(const Matrix3x3& matrix)
{
	double determinant = 0;

	for (int i = 0; i < ALLOWED_MATRIX_DEGREE; ++i)
		determinant = determinant
		+ (matrix.values[0][i] * (matrix.values[1][(i + 1) % ALLOWED_MATRIX_DEGREE] * matrix.values[2][(i + 2) % ALLOWED_MATRIX_DEGREE]
			- matrix.values[1][(i + 2) % ALLOWED_MATRIX_DEGREE] * matrix.values[2][(i + 1) % ALLOWED_MATRIX_DEGREE]));

	return determinant;
}

optional<Matrix3x3> InvertMatrix(const Matrix3x3& matrix)
{
	Matrix3x3 invertedMatrix;

	double determinant = GetMatrixDeterminant(matrix);

	if (determinant == 0)
	{
		return nullopt;
	}

	for (int i = 0; i < ALLOWED_MATRIX_DEGREE; i++) {
		for (int j = 0; j < ALLOWED_MATRIX_DEGREE; j++)
		{
			double minor = ((matrix.values[(j + 1) % 3][(i + 1) % 3] * matrix.values[(j + 2) % 3][(i + 2) % 3])
				- (matrix.values[(j + 1) % 3][(i + 2) % 3] * matrix.values[(j + 2) % 3][(i + 1) % 3]));
			invertedMatrix.values[i][j] = minor / determinant;
		}
	}

	return invertedMatrix;
};

int main(int argc, char* argv[])
{
	auto args = ParseInputArgs(argc, argv);

	if (!args)
	{
		cout << "Incorrect number of arguments have been provided - " << argc << ". Required params number - " << REQUIRED_VALUES_NUMBER << endl;
		cout << "Make sure sure that your running command matches this pattern: invert.exe <inputFileName>" << endl;

		return 1;
	}

	ifstream input;
	input.open(args->inputFileName);
	if (!input.is_open())
	{
		cout << "Couldn't open " << argv[1] << " for reading." << endl;
		return 1;
	}

	auto matrix = ReadMatrixFromStream(input);

	if (!matrix)
	{
		cout << "Incorrect matrix form. Fix input file and try again." << endl;
		return 1;
	}

	auto invertedMatrix = InvertMatrix(*matrix);

	if (!invertedMatrix)
	{
		cout << "Matrix with zero determinant doesn't have inverse matrix.";
		return 0;
	}

	PrintMatrix(*invertedMatrix);

	if (input.bad())
	{
		cerr << "Failed to read data from input file." << endl;
		return 1;
	}

	return 0;
}
