# 도박용사 The Society

한정된 시간 · 돈 · 체력으로 주인공의 삶을 꾸리며 빈곤의 구조를 선택과 결과로 체감하는 육성 시뮬레이션입니다.
2025 통합사회 시리어스 게임콘텐츠 제작 프로젝트입니다.

- **포트폴리오**: [도박용사 The Society (노션)](https://www.notion.so/316048b7ae348029ac99fd616f471e01)
- **플레이 영상**: https://youtu.be/G-BsUse9-8k
- **인원 · 기간**: 3명 (프로그래머 3명) · 2025.07.09 ~ 2025.09.29 · 저는 팀장 · 클라이언트 프로그래밍
- **엔진**: Unity · C#

> 이 저장소는 **코드 열람용**입니다. 원본 프로젝트에서 유료 에셋을 사용하고 있어 코드만 별도로 분리했고,
> 제가 직접 작성한 코드만 선별했습니다. 씬 · 프리팹 · 아트가 빠져 있어서 이 저장소만으로는 빌드되지 않습니다.

## 먼저 볼 코드

기준 폴더는 `Code/`입니다.

- **스탯** — 스탯 데이터로 `BaseStat`을 만들고, 값 변경 규칙은 `IModifierStat` 인터페이스로 분리했습니다
  - `Stat/` (`Stats.cs` · `BaseStat.cs` · `IModifierStat.cs`)
- **UI 규격** — `IUIElement<T>` 제네릭 인터페이스로 UI 컴포넌트의 초기화 · 갱신 규격을 맞췄습니다
  - `UI/IUIElement.cs` · `UI/StatsUI.cs`
- **UI 연출** — 패널 전환과 호버 연출 (DOTween)
  - `UI/HoverScaleUI.cs` · `UI/ShowUI.cs`
- **사운드** — 사운드 요청을 이벤트로 받고, 오브젝트 풀에서 꺼낸 플레이어로 재생합니다. 볼륨은 AudioMixer 3채널 + `PlayerPrefs`에 저장합니다
  - `Manager/SoundManager.cs` · `Sounds/` · `Event/`

## 출처

숨기지 않고 구분해 둡니다.

| 부분 | 출처 |
|---|---|
| EventBus (`Member.Core.EventBus`) | 팀원이 만든 코드를 사용 (이 저장소에는 없음) |
| 오브젝트 풀 · 의존성 주입 (`GondrLib`) | 수업 라이브러리 (이 저장소에는 없음) |

## 의존성 (이 저장소에 포함되지 않음)

DOTween · GondrLib(수업 라이브러리) · EventBus(팀 코드)
