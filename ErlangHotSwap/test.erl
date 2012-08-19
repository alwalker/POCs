-module(test).
 
-export([start/0, loop/1]).
 
loop(Count) ->
    receive
    after
        2000 ->
            io:format("looooop #~p~n", [Count]),
            ?MODULE:loop(Count + 1)
            end.
 
start() ->
    spawn(?MODULE, loop, [1]).