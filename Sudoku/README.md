Sudoku Algoritm of my version.

As we know the rules of Sudoku problem or game

It is 9*9 matrix which has been divided in 3*3.

Rules of the game or problem are pretty simple.

The sub section 3*3 matrix should contains all the numbers 1-9.

Also, the number 1-9 should also appear once in row or column of 9*9 matrix. 


|   1   |	  2   |   3   |	  4   |	  5   | 	6   |	  7   |   8   |	  9   |

|   4   |	  5   |	  6   |	  7	  |   8	  |   9   | 	1	  |   2 	|   3   |

|   7	  |   8 	|   9 	|   1   | 	2   | 	3   |	  4	  |   5   | 	6   |

|   2	  |   3	  |   1   | 	5   |	  6   | 	4   |	  8   |	  9   |	  7   |

|   5   | 	6   | 	4   |	  8   |	  9   | 	7   |	  2   | 	3   | 	1   |

|   8   | 	9   |	  7   |	  2   | 	3   |	  1   | 	5   | 	6   | 	4   |

|   3   |	  1   |	  2   |	  6   |	  4   |	  5   | 	9   | 	7   | 	8   |

|   6	  |   4   |	  5   |	  9   |	  7   | 	8   |	  3   |	  1   | 	2   |

|   9   |	  7   | 	8   |	  3   | 	1   |	  2   | 	6   |	  4   |   5   |


Steps to create the matrix - Means create Sudoku matrix using below simple algortithm

1. put 1 - 9 number in each square sequencially in first row
e.g. 1 2 3 4 5 6 7 8 9

2. Then select 1 box of 3*3 matrix
      It should contains 1 2 3 in first row
      Put 4 5 6  in second row
      and 7 8 9 in third row
      
      You will get 
      1 2 3
      4 5 6
      7 8 9
      
3.  Then select 2nd horizantally consecutive 3*3 box
      It should contains 4 5 6 in first row
      put 7 8 9 in second row
      and 1 2 3 in third row
      
      You will get 
      4 5 6
      7 8 9
      1 2 3
      
4.  Then select 2nd horizantally consecutive 3*3 box
      It should contains 7 8 9 in first row
      put 1 2 3 in second row
      and 4 5 6 in third row
      
      You will get 
      7 8 9
      1 2 3
      4 5 6

After first 4 steps first three rows of 9*9 matrix will contain data as below,

| 1 2 3 | 4 5 6 | 7 8 9 |
| 4 5 6 | 7 8 9 | 1 2 3 |
| 7 8 9 | 1 2 3 | 4 5 6 |
      

      
