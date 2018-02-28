# Unity 2D-Backend:
### Description:
A work in progress backend for top down 2D games in Unity.



### To-Do:
#### Behavior Script
#### 	Movement Commands

- [x] Move <direction> <duration>

      - Causes the Character to move in the given direction for the duration.


- [x] Stop <duration>

      - Causes the Character to stop preforming actions for the duration.


- [x] Face <direction> <duration>

      - Causes the Character to face the given direction for the duration.



#### Example:

```yaml
# > Commands
# move <direction> <duration>
# stop <duration>
# face <direction> <duration>

# Test face
face left .5
face up-left .5
face up .5
face up-right .5
face right .5
face down-right .5
face down-left .5

# Test stop
stop 1

# Test move
move left .25
move up-left .25
move up .25
move up-right .25
move right .25
move down-right .25
move down .25
move down-left .25
```



#### Results:

![Movement Script Gif][movement-script-gif]



### Credits:

|    ![christopher][christopher-avatar]    |    ![xavier][xavier-avatar]    |
| :--------------------------------------: | :----------------------------: |
| [Christopher Martin][christopher-profile] | [Xavier Kelly][xavier-profile] |

[movement-script-gif]: https://i.imgur.com/YktUSig.gif

[christopher-profile]: https://github.com/ChristopherWMM
[christopher-avatar]: https://avatars0.githubusercontent.com/u/9260792?s=125&amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;v=4

[xavier-profile]: https://github.com/xkel
[xavier-avatar]: https://avatars.githubusercontent.com/u/22240889?s=125&amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;amp;v=4


