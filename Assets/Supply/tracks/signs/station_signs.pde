String[] StationNames = { "", "ニの前", "銀車", "八雲", "白楼", "楼観", "さり", "山崎", "晴見", "晴見東", "大空", "日山", "日山神社" };
PFont Font;

float[] TextLeadings = {0f, 0f, 120f, 90f, 60f};

void setup()
{
  size(64, 256);
  rectMode(CENTER);
  Font = createFont("MS Gothic", 48);
}

void draw()
{
  if (frameCount >= StationNames.length)
  {
    return;
  }
  
  textFont(Font, 48);
  textAlign(CENTER, CENTER);
  fill(0);
  
  background(255, 224, 0);
  textLeading(TextLeadings[StationNames[frameCount].length()]);
  text(StationNames[frameCount], width/2, height/2, width, height);
  saveFrame("stationSign##.png");
}
