# Rabin-Karp pattern searching algorithm
The algorithm is modified version of naive algorithm, the difference is that we use hashes for a comparison. If hash of certain substring is equal to pattern's, then we compare each letter, to avoid collision cases.
### Time complexity:
O(m*n), where m is the length of pattern, and n is the length of string we are processing
