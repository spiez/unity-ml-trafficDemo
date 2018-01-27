# Unity ML Agents - Traffic Demo

This is a very short-lived project I've worked on spare time during Christmas 2017.

The idea is to train an agent to navigate static traffic on a three-lane road strip,
using the curriculum learning approach, the agent improves its abilities to dodge cars.

Curriculum learning is set so that the goal is set further down the road at each curriculum
step.

Results are mixed, on the first steps, cumulative reward reaches 1 or even better but when
the goal is too far away, curriculum is not enough, leading the agent to an alleged local
minima state and hence not converging and cumulative reward fuction stays stationary or
diminishing.

Forked from:
https://github.com/Unity-Technologies/ml-agents


