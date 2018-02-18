## Sudoku Algoritm from my view.

As we know the rules of Sudoku problem or game

It is 9\*9 matrix which has been divided in 3\*3.

Rules of the game or problem are pretty simple.

The sub section 3\*3 matrix should contains all the numbers 1-9.

Also, the number 1-9 should also appear once in row or column of 9\*9 matrix. 


|   1   |	  2   |   3   |	  4   |	  5   | 	6   |	  7   |   8   |	  9   |

|   4   |	  5   |	  6   |	  7	  |   8	  |   9   | 	1	  |   2 	|   3   |

|   7	  |   8 	|   9 	|   1   | 	2   | 	3   |	  4	  |   5   | 	6   |

|   2	  |   3	  |   1   | 	5   |	  6   | 	4   |	  8   |	  9   |	  7   |

|   5   | 	6   | 	4   |	  8   |	  9   | 	7   |	  2   | 	3   | 	1   |

|   8   | 	9   |	  7   |	  2   | 	3   |	  1   | 	5   | 	6   | 	4   |

|   3   |	  1   |	  2   |	  6   |	  4   |	  5   | 	9   | 	7   | 	8   |

|   6	  |   4   |	  5   |	  9   |	  7   | 	8   |	  3   |	  1   | 	2   |

|   9   |	  7   | 	8   |	  3   | 	1   |	  2   | 	6   |	  4   |   5   |


### Steps to create the matrix - Means create Sudoku matrix using below simple algortithm

put 1 - 9 number in each square sequencially in first row e.g. 1 2 3 4 5 6 7 8 9

Then select 1st box of 3\*3 matrix.
  * It should contains 1 2 3 in first row
  * put 4 5 6 in second row 
  * and 7 8 9 in third row

You will get 

1 2 3 

4 5 6 

7 8 9

Then select 2nd horizantally consecutive 3\*3 box.

  * It should contains 4 5 6 in first row 
  * put 7 8 9 in second row 
  * and 1 2 3 in third row

You will get

4 5 6 

7 8 9 

1 2 3

Then select 2nd horizantally consecutive 3\*3 box 

* It should contains 7 8 9 in first row 

* put 1 2 3 in second row 

* and 4 5 6 in third row

You will get 
7 8 9 

1 2 3

4 5 6

After first 4 steps first three rows of 9\*9 matrix will contain data as below,

| 1 2 3 | 4 5 6 | 7 8 9 | 

| 4 5 6 | 7 8 9 | 1 2 3 | 

| 7 8 9 | 1 2 3 | 4 5 6 |


5. In this step we have select the 3\*3 box 
This will start 4th row of 9\*9 matrix

Here we should start from

* 2 3 1 in first row of selected 3\*3
* 5 6 4 in second row
* 8 9 7 in third row

then 3*3 box should contain values as below,

2 3 1

5 6 4

8 9 7

6. In this step we should select next horizantally consecutive 3\*3 box

Similar to 5th step, here we should start from 

* 5 6 4 in first row
* 8 9 7 in second row
* 2 3 1 in third row 

Output of 6th steps would be like this

5 6 4

8 9 7

2 3 1

7. In this step we should select next horizantally consecutive 3\*3 box

Similar to 5th and 6th step, here we should start from 

* 8 9 7 in first row
* 2 3 1 in second row 
* 5 6 4 in third row

Output of 6th steps would be like this

8 9 7

2 3 1

5 6 4

4th, 5th and 6th row 9\*9 would be like this after above steps

| 7 8 9 | 1 2 3 | 4 5 6 |

| 2 3 1 | 5 6 4 | 8 9 7 |

| 5 6 4 | 8 9 7 | 2 3 1 |

After the 7th step, complete matrix of 9\*9 would be look like this

| 1 2 3 | 4 5 6 | 7 8 9 | 

| 4 5 6 | 7 8 9 | 1 2 3 | 

| 7 8 9 | 1 2 3 | 4 5 6 |

| 2 3 1 | 5 6 4 | 8 9 7 |

| 5 6 4 | 8 9 7 | 2 3 1 |

| 8 9 7 | 2 3 1 | 5 6 4 |



8. In this step we have select next 3\*3 box 
This will start from 7th row of 9\*9 matrix


Here we should start from

* 3 1 2 in first row of selected 3\*3
* 6 4 5 in second row
* 9 7 8 in third row

then 3*3 box should contain values as below,

3 1 2

6 4 5

9 7 8

9. In this step we should select next horizantally consecutive 3\*3 box

Similar to 8th step, here we should start from 

* 6 4 5 in first row
* 9 7 8 in second row
* 3 1 2 in third row 

Output of 6th steps would be like this

6 4 5

9 7 8

3 1 2

10. In this step we should select next horizantally consecutive 3\*3 box

Similar to 8th and 9h step, here we should start from 

* 9 7 8 in first row
* 3 1 2 in second row 
* 6 4 5 in third row

Output of 6th steps would be like this

9 7 8

3 1 2

6 4 5

6th, 7th and 9th row 9\*9 would be like this after above steps

| 3 1 2 | 6 4 5 | 9 7 8 |

| 6 4 5 | 9 7 8 | 3 1 2 |

| 9 7 8 | 3 1 2 | 6 4 5 |

After 8th, 9th and 10th step, complete matrix of 9\*9 would be look like as below,

| 1 2 3 | 4 5 6 | 7 8 9 | 

| 4 5 6 | 7 8 9 | 1 2 3 | 

| 7 8 9 | 1 2 3 | 4 5 6 |

| 2 3 1 | 5 6 4 | 8 9 7 |

| 5 6 4 | 8 9 7 | 2 3 1 |

| 8 9 7 | 2 3 1 | 5 6 4 |

| 3 1 2 | 6 4 5 | 9 7 8 |

| 6 4 5 | 9 7 8 | 3 1 2 |

| 9 7 8 | 3 1 2 | 6 4 5 |
