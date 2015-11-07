namespace _2D_Singleplayer_Engine.Graphics
{
    interface IInput
    {
        void KeyPress(object arg1, object arg2);
        void KeyRelease(object arg1, object arg2);

        void MouseDown(object arg1, object arg2);
        void MouseUp(object arg1, object arg2);
        void MouseMove(object arg1, object arg2);
    }
}
