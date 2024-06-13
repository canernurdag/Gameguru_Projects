# Gameguru_Project2
- Unity 2021.3.13
- DI Framework: Zenject
- Design Patterns: Factory, Observer, DI
- Design Principle: SOLID principles
- Camera Solution: Cinemachine
- Naming Convention: https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md
# Gameplay Video:
 https://www.youtube.com/shorts/afXeXJCVJX4
# Gameplay
- The purpose is reaching to finishline.
- StackPart is divided into 2 pieces on OnInputDown event. 
- Division logic is according to previous stackpart's position and scale value
- There is a threshold which is around 15%. If the position is within the threshold, it counts as perfect.
- There is a perfect placement streak which effects audiosource's volume pitch.
- When the level is finished successfully, the character plays the dance anim and cinemachine VCAM performs orbit movement around the character.
- The scene does not reload for the next level. The next level is build by respecting to the previous level.  
